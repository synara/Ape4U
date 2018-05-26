using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class NotificacaoReuniao
    {
        public int Id { get; set; }
        public Notificacao Notificacao { get; set; }
        public int NotificacaoId { get; set; }
        public Reuniao Reuniao { get; set; }
        public int ReuniaoId { get; set; }

        public static NotificacaoReuniao Criar(int reuniaoId, int notificacaoId)
        {
            return new NotificacaoReuniao()
            {
               NotificacaoId = notificacaoId,
               ReuniaoId = reuniaoId
            };
        }
    }
}