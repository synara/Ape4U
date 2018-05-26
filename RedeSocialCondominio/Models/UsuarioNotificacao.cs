using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    [Table("UsuarioNotificacoes")]
    public class UsuarioNotificacao
    {
        public int Id { get; set; }
        public Notificacao Notificacao { get; set; }
        public int NotificacaoId { get; set; }
        public bool IsLido { get; set; }
        public Usuarios Usuario { get; set; }
        public string UsuarioId { get; set; }
        public DateTime Data { get; set; }

        public static UsuarioNotificacao Criar(Notificacao notificacao, string usuarioId, DateTime dia)
        {
            return new UsuarioNotificacao
            {
                IsLido = false,
                NotificacaoId = notificacao.Id,
                Notificacao = notificacao,
                UsuarioId = usuarioId,
                Data = dia
            };

        }

        public void Lido()
        {
            this.IsLido = true;
        }
    }
}