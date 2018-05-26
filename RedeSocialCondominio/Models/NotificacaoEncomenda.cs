using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class NotificacaoEncomenda
    {
        public int Id { get; set; }
        public Notificacao Notificacao { get; set; }
        public int NotificacaoId { get; set; }
        public Encomenda Encomenda { get; set; }
        public int EncomendaId { get; set; }

        public static NotificacaoEncomenda Criar(int notificacaoId, int encomendaId)
        {
            return new NotificacaoEncomenda()
            {
                EncomendaId = encomendaId,
                NotificacaoId = notificacaoId
            };
        }

    }
}