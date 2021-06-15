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
    public class ApostasService : Apostas.ApostasBase
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
            Bet aposta = new Bet
            {
                Chave = request.Aposta.Chave,
                DataRegisto = request.Aposta.Data,
                Arquivada = false,
                User = user
            };
            _db.Add(aposta);

            try
            {
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
                    .Where(x => x.Arquivada == false && x.User.Nome != "Vencedora").ToListAsync();
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

            _logger.LogInformation("Admin requested list of bets. {0} bets were returned.", bets.Count());
            return await Task.FromResult(new ListaApostas { Aposta = { listaApostas } });
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
            ListaUtilizadores userList = new ListaUtilizadores();
            var users = await _db.Bets.Include(b => b.User)
                .Where(x => x.Arquivada == false && x.User.Nome != "Vencedora")
                .Select(a => a.User.Nome).ToListAsync();
            foreach (var u in users)
            {
                userList.Utilizador.Add(u);
            }

            _logger.LogInformation("Admin requested current users. {0} users were returned.", users.Count());
            return await Task.FromResult(userList);
        }

        public override async Task<Resultado> RegistarChaveVencedora(ChaveVencedora request, ServerCallContext context)
        {
            var existeChaveVencedora = await _db.Bets.Include(x => x.User)
                .Where(b => b.Arquivada == false)
                .AnyAsync(u => u.User.Nome == "Vencedora");
            if (existeChaveVencedora)
            {
                _logger.LogError("Gestor tried to register winning key, but there already exists an unarchived winning key.");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }

            var userChaveVencedora = await _db.Users.FirstOrDefaultAsync(u => u.Nome == "Vencedora");
            if (userChaveVencedora == null)
            {
                userChaveVencedora = new User { Nome = "Vencedora" };
                _db.Add(userChaveVencedora);
            }

            var apostaVencedora = new Bet
            {
                Chave = request.Chave,
                DataRegisto = DateTime.Now.ToString(),
                Arquivada = false,
                User = userChaveVencedora
            };
            _db.Add(apostaVencedora);

            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation("Gestor registered winnig bet: {0}.", apostaVencedora.Chave);
                return await Task.FromResult(new Resultado { Sucesso = true });
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "Error updating database -> \"ApostasService.cs\": RegistarChaveVencedora.");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        public override async Task<ListaApostasVencedoras> ListarApostasVencedoras(PedidoApostasVencedoras request, ServerCallContext context)
        {
            var apostaVencedora = await _db.Bets.Include(x => x.User)
                .Where(b => b.User.Nome == "Vencedora")
                .FirstOrDefaultAsync(b => b.Arquivada == false);

            var apostas = await _db.Bets.Include(x => x.User)
                .Where(a => a.Arquivada == false
                    && a.User.Nome != "Vencedora"
                    && a.Chave == apostaVencedora.Chave)
                        .ToListAsync();

            List<Aposta> apostasLista = new List<Aposta>();
            foreach (var a in apostas)
            {
                apostasLista.Add(new Aposta { Chave = a.Chave, Data = a.DataRegisto, Nome = a.User.Nome });
            }

            _logger.LogInformation("Gestor requested winning keys. {0} keys were returned.", apostasLista.Count());
            return await Task.FromResult(new ListaApostasVencedoras { Aposta = { apostasLista } });
        }
    }
}
