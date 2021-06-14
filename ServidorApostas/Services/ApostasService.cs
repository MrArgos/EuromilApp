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
                return await Task.FromResult(new Resultado { Sucesso = true });
            }
            catch (DbUpdateException)
            {
                //Console.WriteLine("Error updating database -> \"ApostasService.cs\": line 35");
                _logger.LogError("Error updating database -> \"ApostasService.cs\": line 35");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        //public override Task<ListaApostas> ListarApostas(PedidoListaApostas request, ServerCallContext context)
        //{

        //    return base.ListarApostas(request, context);
        //}
    }
}
