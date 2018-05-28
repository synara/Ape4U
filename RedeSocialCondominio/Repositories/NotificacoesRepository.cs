using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class NotificacoesRepository : INotificacoesRepository
    {
        private ApplicationDbContext _ctx;

        public NotificacoesRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Notificacao notificacao)
        {
            _ctx.Notificacoes.Add(notificacao);

        }

        public List<UsuarioNotificacao> NotificacoesForamLidas(string usuarioId)
        {
            return _ctx.UsuarioNotificacoes.Where(u => u.UsuarioId == usuarioId && !u.IsLido).Take(5).ToList();
        }

        public List<Notificacao> NotificacoesParaUsuarios(string usuarioId)
        {
            return _ctx.UsuarioNotificacoes
                .Where(n => n.UsuarioId == usuarioId && !n.IsLido)
                .Select(n => n.Notificacao)
                .Take(5)
                .ToList();
        }
    }
}