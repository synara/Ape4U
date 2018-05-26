﻿using Microsoft.AspNet.Identity;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;
using RedeSocialCondominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedeSocialCondominio.Controllers
{
    [Authorize]
    public class HorarioController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        // GET: Horario
        public ActionResult Index()
        {
            var vm = new AgendarHorarioViewModel();
            var nomeUsuario = User.Identity.Name;
            vm.NomeVisitante = nomeUsuario.Split('-')[0];
            vm.Dia = DateTime.Now.ToLocalTime();
            vm.Hora = DateTime.Now.ToString("HH:mm");

            return View(vm);
        }

        [HttpPost]
        public ActionResult AgendarHorario(AgendarHorarioViewModel vm)
        {
            DateTime Hora = DateTime.Parse(vm.Hora);

            if (Util.Util.VerificarHorario(Hora))
            {
                var horario = Horario.Criar(vm.NomeVisitante, vm.Dia, Hora, User.Identity.GetUserId());
                unitOfWork.Horarios.Adicionar(horario);
                unitOfWork.Complete();
                vm.Agendou = true;

            } else
            {
                vm.Falhou = true;
            }

            return View("Index", vm);
        }
    }
}