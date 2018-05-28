using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class NotificacaoMudancaRepository : INotificacaoMudancaRepository
    {

        private ApplicationDbContext _ctx;

        public NotificacaoMudancaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Salvar(NotificacaoMudanca mudanca)
        {
            _ctx.NotificacaoMudanca.Add(mudanca);
        }
    }
}