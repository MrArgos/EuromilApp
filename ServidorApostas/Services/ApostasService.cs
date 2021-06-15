using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServidorApostas.Data;
using ServidorApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServidorApostas
{
    public class ApostasService: Apostas.ApostasBase
    {
        private readonly ILogger<ApostasService> _logger;
        private readonly ApostasServerContext _db;

        public ApostasService(ILogger<ApostasService> logger, ApostasServerContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        public override async Task<Resultado> RegistarAposta(PedidoAposta request, ServerCallContext context)
        {
            var user = _db.Users.Where(x => x.Nome == request.Aposta.Nome).FirstOrDefault();
            if (user == null)
            {
                user = new User { Nome = request.Aposta.Nome };
                _db.Add(user);
            }
            Bet aposta = new Bet { 
                Chave = request.Aposta.Chave, 
                DataRegisto = request.Aposta.Data, 
                Arquivada = false, 
                User = user
            };

            try
            {
                _db.Add(aposta);
                await _db.SaveChangesAsync();
                _logger.LogInformation("User {0} registered key: {1}", user.Nome, aposta.Chave);
                return await Task.FromResult(new Resultado { Sucesso = true });
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "Error updating database -> \"ApostasService.cs\": RegistarAposta");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        public override async Task<ListaApostas> ListarApostas(PedidoListaApostas request, ServerCallContext context)
        {
            List<Aposta> listaApostas = new List<Aposta>();
            List<Bet> bets = new List<Bet>();

            if (request.Nome == "")
            {
                bets = await _db.Bets.Include(b => b.User)
                    .Where(x => x.Arquivada == false).ToListAsync();
            }
            else
            {
                var user = await _db.Users.Where(x => x.Nome == request.Nome).FirstOrDefaultAsync();
                if (user != null)
                {
                    bets = await _db.Bets.Include(b => b.User)
                        .Where(x => x.UserID == user.Id).ToListAsync();
                }
            }
            foreach (var b in bets)
            {
                var ap = new Aposta { Nome = b.User.Nome, Chave = b.Chave, Data = b.DataRegisto };
                listaApostas.Add(ap);
            }

            ListaApostas listaResposta = new ListaApostas { Aposta = { listaApostas } };

            _logger.LogInformation("Admin requested list of bets. {0} bets were returned.", bets.Count());
            return await Task.FromResult(listaResposta);
        }

        public override async Task<Resultado> ArquivarApostas(PedidoArquivar request, ServerCallContext context)
        {

            var apostasCorrentes = _db.Bets.Where(x => x.Arquivada == false).ToList();
            foreach (var ap in apostasCorrentes)
            {
                ap.Arquivada = true;
            }

            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation("Admin requested to archive bets. {0} bets were archived.", apostasCorrentes.Count());
                return await Task.FromResult(new Resultado { Sucesso = true });
            }
            catch (DbUpdateException e)
            {   
                _logger.LogError(e, "Error updating database -> \"ApostasService.cs\": ArquivarAposta");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        public override async Task<ListaUtilizadores> ListarUtilizadores(PedidoListaUtilizadores request, ServerCallContext context)
        {
            List<string> userList = new List<string>();
            ListaUtilizadores lu = new ListaUtilizadores();
            var users = await _db.Bets.Include(b => b.User).Where(x => x.Arquivada == false).Select(a => a.User.Nome).ToListAsync();
            foreach (var u in users)
            {
                lu.Utilizador.Add(u);
            }

            _logger.LogInformation("Admin requested current users. {0} users were returned.", users.Count());
            return await Task.FromResult(lu);
        }
    }
}
