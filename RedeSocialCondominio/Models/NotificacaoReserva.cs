using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class NotificacaoReserva
    {
        public int Id { get; set; }
        public Reserva Reserva { get; set; }
        public int ReservaId { get; set; }
        public Notificacao Notificacao { get; set; }
        public int NotificacaoId { get; set; }

        public static NotificacaoReserva Criar(int reservaId, int notificacaoId)
        {
            return new NotificacaoReserva {
                ReservaId = reservaId,
                NotificacaoId = notificacaoId
            };
        }
    }
}