using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class NotificacaoOcorrencia
    {
        public int Id { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public int OcorrenciaId { get; set; }
        public Notificacao Notificacao { get; set; }
        public int NotificacaoId { get; set; }

        public static NotificacaoOcorrencia Criar(int ocorrenciaId, int notificacaoId)
        {
            return new NotificacaoOcorrencia()
            {
                NotificacaoId = notificacaoId,
                OcorrenciaId = ocorrenciaId
            };
        }
    }
}