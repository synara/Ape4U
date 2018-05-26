using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Repositories
{
    public interface INotificacaoReservaRepository
    {
        void Add(NotificacaoReserva notificacaoReserva); 
    }
}