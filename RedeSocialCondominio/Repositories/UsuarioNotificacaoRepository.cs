using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;

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
    }
}