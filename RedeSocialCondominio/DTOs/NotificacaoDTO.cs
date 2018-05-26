using RedeSocialCondominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.DTOs
{
    public class NotificacaoDTO
    {
        public string Assunto { get; set; }
        public DateTime? Dia { get; set; }
        public DateTime? HoraInicial { get; set; }
        public DateTime? HoraFinal { get; set; }
        public string Espaco { get; set; }
        public int TipoNotificacaoId { get; set; }
        public TipoNotificacao? TipoNotificacao { get; set; }
        public string Descricao { get; internal set; }
        public int? PerfilId { get; internal set; }
        public bool Entregue { get; set; }
        public DateTime? HoraEncomendaEntregue { get; set; }
    }
}