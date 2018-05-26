using Microsoft.AspNet.Identity;
using RedeSocialCondominio.DTOs;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;
using RedeSocialCondominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace RedeSocialCondominio.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new Models.ApplicationDbContext());
        // GET: Reserva
        public ActionResult Index()
        {
            return View(new LocaisViewModel()
            {
                Locais = unitOfWork.Locais.GetAllLocais(),
                UserId = User.Identity.GetUserId()
            });
        }

        public JsonResult GetReservas()
        {
            var reservas = unitOfWork.Reservas.GetReservas();
            
            return new JsonResult
            {
                Data = reservas,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public JsonResult Salvar(ReservaDTO dto)
        {
            string status = null;
            Reserva reserva = null;

            var reservaValidada = Util.Util.ValidarReserva(dto, User.Identity.GetUserId());
            var local = unitOfWork.Locais.GetLocalPorId(dto.LocalId).Nome;
            
            if (dto.Id > 0 && string.IsNullOrEmpty(reservaValidada))
            {
                reserva = EditarReserva(dto);
                status = "Reserva editada com sucesso!";
                unitOfWork.Complete();

            }
            else if(String.IsNullOrEmpty(reservaValidada))
            {
                reserva = Reserva.Criar(dto.Nome, dto.Descricao, dto.HoraDiaInicio, dto.HoraDiaFinal, 
                                            dto.HoraDiaExtraInicial, dto.HoraDiaExtraFinal, dto.LocalId, 
                                            User.Identity.GetUserId(), dto.CorReserva);

                unitOfWork.Reservas.Adicionar(reserva);
                unitOfWork.Complete();
                status = "Reserva feita com sucesso!";
                NotificarReserva(reserva);

            } else
            {
                status = reservaValidada;
            }

            
            return new JsonResult { Data = new { status = status } };
        }

        private Reserva EditarReserva(ReservaDTO dto)
        {
            Reserva reserva = unitOfWork.Reservas.GetReservaPorId(dto.Id);
            if (reserva != null && reserva.UserId == User.Identity.GetUserId())
            {
                reserva.Id = dto.Id;
                reserva.HoraFim = Convert.ToDateTime(dto.HoraDiaFinal);
                reserva.HoraInicio = Convert.ToDateTime(dto.HoraDiaInicio);
                reserva.Descricao = dto.Descricao;
                reserva.HoraExtraFinal = Util.Util.ValidarHoras(dto.HoraDiaExtraFinal);
                reserva.HoraExtraInicial = Util.Util.ValidarHoras(dto.HoraDiaExtraInicial);
                reserva.IsDiaTodo = dto.isDiaTodo;
                reserva.LocalId = dto.LocalId;
                reserva.UserId = User.Identity.GetUserId();
                reserva.CorReserva = dto.CorReserva;
            }

            return reserva;
        }

        [HttpPost]
        public JsonResult Deletar(int reservaId)
        {
            var status = false;
            var reserva = unitOfWork.Reservas.GetReservaPorId(reservaId);
            if (reserva != null) unitOfWork.Reservas.Deletar(reservaId);

            unitOfWork.Complete();
            status = true;

            return new JsonResult { Data = new { status = status } };
        }

        public void NotificarReserva(Reserva r)
        {
            var nomeLocal = unitOfWork.Locais.GetLocalPorId(r.LocalId.Value).Nome;
            var notificacao = Notificacao.NotificarReserva(r, nomeLocal);
            unitOfWork.Notificacoes.Add(notificacao);
            unitOfWork.Complete();

            var notificacaoReserva = NotificacaoReserva.Criar(r.Id, notificacao.Id);
            unitOfWork.NotificacaoReserva.Add(notificacaoReserva);
            unitOfWork.Complete();

            var usuarios = unitOfWork.Usuarios.GetAllUsuarios();
            UsuarioNotificacao usuarioNotificacao = null;

            foreach (var u in usuarios)
            {
                usuarioNotificacao = UsuarioNotificacao.Criar(notificacao, u.UsuarioId, DateTime.Now);
                unitOfWork.UsuariosNotificacao.Add(usuarioNotificacao);
                unitOfWork.Complete();
            }

        }
    }
}

