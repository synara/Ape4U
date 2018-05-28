using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface INotificacaoReuniaoRepository
    {
        void Add(NotificacaoReuniao reuniao);
        List<NotificacaoReserva> GetAllReunioes();
        List<NotificacaoReserva> GetAllReunioesPorId(int id);
    }
}
