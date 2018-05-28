using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class NotificacaoMudanca
    {
        public int Id { get; set; }
        public Mudanca Mudanca { get; set; }
        public int MudancaId { get; set; }
        public Notificacao Notificacao { get; set; }
        public int NotificacaoId { get; set; }

        public static NotificacaoMudanca Criar(int notificacaoId, int mudancaId)
        {
            return new NotificacaoMudanca()
            {
                MudancaId = mudancaId,
                NotificacaoId = notificacaoId
            };
        }
    }
}