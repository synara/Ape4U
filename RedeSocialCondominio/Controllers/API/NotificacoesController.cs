

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RedeSocialCondominio.DTOs;
using RedeSocialCondominio.Enums;
using RedeSocialCondominio.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RedeSocialCondominio.Controllers.API
{
    public class NotificacoesController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new Models.ApplicationDbContext());

        public IEnumerable<NotificacaoDTO> GetNovasNotificacoes(string usuarioId)
        {
            var notificacoes = unitOfWork.Notificacoes.NotificacoesParaUsuarios(usuarioId);
            var dto = new List<NotificacaoDTO>();

            foreach (var n in notificacoes)
            {
                dto.Add(
                    new NotificacaoDTO()
                    {
                        TipoNotificacaoId = n.TipoNotificacaoId,
                        Assunto = n.Assunto,
                        Dia = n.Dia,
                        Espaco = n.Espaco,
                        HoraFinal = n.HoraFinal,
                        HoraInicial = n.HoraInicial,
                        TipoNotificacao = n.TipoNotificacao,
                        Descricao = n.Descricao,
                        PerfilId = unitOfWork.Usuarios.GetUsuarioPorId(usuarioId).PerfilId,
                        HoraEncomendaEntregue = n.HoraEmQueOcorreu
                    }
                );
            }

            return dto;
        }

        [HttpPost]
        public IHttpActionResult NotificacoesForamLidas(string usuarioId)
        {
            var notificacoes = unitOfWork.Notificacoes.NotificacoesForamLidas(usuarioId);

            notificacoes.ForEach(n => n.Lido());

            unitOfWork.Complete();

            return Ok();
        }
    }
}
