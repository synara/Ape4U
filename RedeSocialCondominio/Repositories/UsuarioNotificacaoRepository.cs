using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;
using RedeSocialCondominio.Enums;

namespace RedeSocialCondominio.Repositories
{
    public class UsuarioNotificacaoRepository : IUsuariosNotificacao
    {
        ApplicationDbContext _ctx;

        public UsuarioNotificacaoRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(UsuarioNotificacao usuarionotificacao)
        {
            _ctx.UsuarioNotificacoes.Add(usuarionotificacao);    
        }

        public List<UsuarioNotificacao> GetAllUsuariosNotificacoes()
        {
            return _ctx.UsuarioNotificacoes.ToList();
        }

        public List<UsuarioNotificacao> GetAllNotificacoesPorTipoEUsuarioId(TipoNotificacao tipo, string usuarioId)
        {
            return _ctx.UsuarioNotificacoes
                .Where(r => r.UsuarioId == usuarioId && r.Notificacao.TipoNotificacao == tipo).ToList();
        }
    }
}