using RedeSocialCondominio.DTOs;
using RedeSocialCondominio.Enums;
using RedeSocialCondominio.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RedeSocialCondominio.Models
{
    [Table("Notificacoes")]
    public class Notificacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? Dia { get; set; }
        public string Assunto { get; set; }
        public DateTime? HoraInicial { get; set; }
        public DateTime? HoraFinal { get; set; }
        public DateTime? HoraEmQueOcorreu { get; set; }
        public string Espaco { get; set; }
        public int? PerfilUsuarioPermitidoAReceber { get; set; }
        public string UsuarioId { get; set; }
        public int TipoNotificacaoId { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }

        public static Notificacao NotificarReserva(Reserva reserva, string nomeLocal)
        {
            return new Notificacao()
            {
                Descricao = reserva.Descricao,
                Dia = reserva.HoraInicio,
                Espaco = nomeLocal,
                HoraInicial = reserva.HoraInicio,
                HoraFinal = reserva.HoraFim,
                UsuarioId = reserva.UserId,
                TipoNotificacao = TipoNotificacao.Reserva
            };
        }

        public static Notificacao NotificarOcorrencia(Ocorrencia o, int perfilId)
        {
            return new Notificacao()
            {
                Descricao = o.Descricao,
                Assunto = o.Assunto,
                Dia = DateTime.Now,
                PerfilUsuarioPermitidoAReceber = perfilId,
                TipoNotificacao = TipoNotificacao.Ocorrencia
            };
        }

        public static Notificacao NotificarReuniao(Reuniao reuniao)
        {
            return new Notificacao()
            {
                HoraInicial = reuniao.HoraInicio,
                HoraFinal = reuniao.HoraFim,
                Assunto = reuniao.Assunto,
                Descricao = reuniao.Descricao,
                Dia = reuniao.Dia,
                TipoNotificacao = TipoNotificacao.Reuniao
            };
        }

        public static Notificacao NotificarEncomendaRecebida(Encomenda encomenda)
        {
            return new Notificacao()
            {
                HoraEmQueOcorreu = encomenda.HoraRecebida,
                TipoNotificacao = TipoNotificacao.Encomenda
            };
        }

        public static Notificacao NotificarMudanca(Mudanca mudanca, string tipoMudanca)  
        {
            return new Notificacao()
            {
                Dia = mudanca.Data,
                TipoNotificacao = TipoNotificacao.Mudanca,
                Assunto = tipoMudanca,
                HoraInicial = mudanca.Hora
            };
        }
    }
}