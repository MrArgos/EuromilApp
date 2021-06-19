/* Trabalho Realizado por:
 * João Costa       al59259
 * Pedro Monteiro   al68708
 * Luis Ribeiro     al69605
 */

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

        // Atender ao pedido RegistarAposta do Cliente Utilizador
        public override async Task<Resultado> RegistarAposta(PedidoAposta request, ServerCallContext context)
        {
            // verificar se já existe utilizador com este nome
            var user = _db.Users.FirstOrDefault(x => x.Nome == request.Aposta.Nome);
            if (user == null)
            {   // se não existir, criar um novo User e adicionar à base de dados
                user = new User { Nome = request.Aposta.Nome };
                _db.Add(user);
            }
            // criar nova aposta e adicionar à base de dados
            Bet aposta = new Bet
            {
                Chave = request.Aposta.Chave,
                DataRegisto = request.Aposta.Data,
                Arquivada = false,
                User = user
            };
            _db.Add(aposta);

            // tentar guardar as alterações na base de dados e responder
            // ao cliente de acordo
            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation("User {0} registered key: {1}", user.Nome, aposta.Chave);
                return await Task.FromResult(new Resultado { Sucesso = true });
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "Error updating database -> ApostasService.cs: RegistarAposta");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        // Atender ao pedido ListarApostas dos clientes Utilizador e Administrador
        public override async Task<ListaApostas> ListarApostas(PedidoListaApostas request, ServerCallContext context)
        {
            List<Aposta> listaApostas = new List<Aposta>();
            List<Bet> bets = new List<Bet>();

            // Se o nome enviado pelo cliente for vazio, quer dizer que foi enviado 
            // pelo Cliente Administrador, ou seja pede todas as apostas
            if (request.Nome == "")
            {
                bets = await _db.Bets.Include(b => b.User)
                    .Where(x => x.Arquivada == false && x.User.Nome != "Vencedora")
                    .OrderByDescending(x => x.DataRegisto).ToListAsync();
            }
            else 
            {   // Caso contrário procura o nome na base de dados e devolve uma lista
                // com as apostas desse User
                var user = await _db.Users.Where(x => x.Nome == request.Nome).FirstOrDefaultAsync();
                if (user != null)
                {
                    bets = await _db.Bets.Include(b => b.User)
                        .Where(x => x.UserID == user.Id)
                        .OrderByDescending(x => x.DataRegisto).ToListAsync();
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

        // Atender ao pedido Arquivar Apostas do Cliente Administrador
        public override async Task<Resultado> ArquivarApostas(PedidoArquivar request, ServerCallContext context)
        {
            // Procurar todas as apostas que não estão arquivadas e alterar a coluna Arquivada
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
                _logger.LogError(e, "Error updating database -> ApostasService.cs: ArquivarAposta");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        // Atender ao pedido Listar Utilizadores do Cliente Administrador
        public override async Task<ListaUtilizadores> ListarUtilizadores(PedidoListaUtilizadores request, ServerCallContext context)
        {
            ListaUtilizadores userList = new ListaUtilizadores();

            // guardar numa lista utilizadores cujo nome não é "Vencedora" (Aposta vencedora)
            // e cujas apostas não estejam arquivadas
            var users = await _db.Bets.Include(b => b.User)
                .Where(x => x.Arquivada == false && x.User.Nome != "Vencedora")
                .Select(a => a.User.Nome).Distinct().ToListAsync();

            foreach (var u in users)
            {
                userList.Utilizador.Add(u);
            }

            _logger.LogInformation("Admin requested current users. {0} users were returned.", users.Count());
            return await Task.FromResult(userList);
        }

        // Atender ao pedido de Registo de Chave Vencedora do Cliente Gestor
        public override async Task<Resultado> RegistarChaveVencedora(ChaveVencedora request, ServerCallContext context)
        {
            // Verificar se já existe alguma chave Vencedora que não esteja arquivada
            var existeChaveVencedora = await _db.Bets.Include(x => x.User)
                .Where(b => b.Arquivada == false)
                .AnyAsync(u => u.User.Nome == "Vencedora");
            if (existeChaveVencedora)   // Se já existir, não deixar inserir uma nova
            {
                _logger.LogWarning("Gestor tried to register winning key, but there already exists an unarchived winning key.");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }

            // Verificar se já existe o User "Vencedora", onde serão associadas as chaves vencedoras
            // Se ainda não existir cria-lo e adicionar à base de dados
            var userChaveVencedora = await _db.Users.FirstOrDefaultAsync(u => u.Nome == "Vencedora");
            if (userChaveVencedora == null)
            {
                userChaveVencedora = new User { Nome = "Vencedora" };
                _db.Add(userChaveVencedora);
            }

            // Adicionar chave vencedora à base de dados
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
                _logger.LogError(e, "Error updating database -> ApostasService.cs: RegistarChaveVencedora.");
                return await Task.FromResult(new Resultado { Sucesso = false });
            }
        }

        // Atender ao pedido de Ver as Apostas Vencedoras do Cliente Gestor
        public override async Task<ListaApostasVencedoras> ListarApostasVencedoras(PedidoApostasVencedoras request, ServerCallContext context)
        {
            // Ver qual é a aposta Vencedora Ativa (User == "Vencedora" e Arquivada == false)
            var apostaVencedora = await _db.Bets.Include(x => x.User)
                .Where(b => b.User.Nome == "Vencedora")
                .FirstOrDefaultAsync(b => b.Arquivada == false);

            List<Bet> apostas = new List<Bet>();

            // Se existir aposta vencedora, procurar na base de dados todas as
            // apostas em que a chave é igual à da chave vencedora
            if (apostaVencedora != null)
            {
                apostas = await _db.Bets.Include(x => x.User)
                        .Where(a => a.Arquivada == false
                            && a.User.Nome != "Vencedora"
                            && a.Chave == apostaVencedora.Chave)
                                .OrderByDescending(x => x.DataRegisto).ToListAsync(); 
            }

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
