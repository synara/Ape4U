using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface INotificacoesRepository
    {
        List<Notificacao> NotificacoesParaUsuarios(string usuarioId);
        List<UsuarioNotificacao> NotificacoesForamLidas(string usuarioId);
        void Add(Notificacao notificacao);
    }
}
