using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class NotificacaoEncomendaRepository : INotificacaoEncomendaRepository
    {
        private ApplicationDbContext _ctx;

        public NotificacaoEncomendaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Salvar(NotificacaoEncomenda encomenda)
        {
            _ctx.NotificacaoEncomenda.Add(encomenda);
        }
    }
}