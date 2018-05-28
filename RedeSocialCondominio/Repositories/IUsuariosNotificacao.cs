using RedeSocialCondominio.Enums;
using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IUsuariosNotificacao
    {
        void Add(UsuarioNotificacao usuarionotificacao);
        List<UsuarioNotificacao> GetAllUsuariosNotificacoes();
        List<UsuarioNotificacao> GetAllNotificacoesPorTipoEUsuarioId(TipoNotificacao tipo, string usuarioId);
    }
}
