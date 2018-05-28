using Microsoft.AspNet.Identity;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;
using RedeSocialCondominio.Util;
using RedeSocialCondominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedeSocialCondominio.Controllers
{
    [Authorize]
    public class VisitanteController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        // GET: Visitante
        public ActionResult Index()
        {
            var vm = new VisitantesViewModel();
            var nomeUsuario = User.Identity.Name;
            vm.NomeUsuarioLogado = nomeUsuario.Split('-')[0];
            vm.DataVisita = DateTime.Now.ToLocalTime();
            vm.HoraVisita = DateTime.Now.ToString("HH:mm");
            vm.MeusVisitantes = unitOfWork.Visitantes.GetTodosVisitantesPorUsuario(User.Identity.GetUserId());

            return View(vm);
        }

        [HttpPost]
        public ActionResult RegistrarVisitante(VisitantesViewModel vm)
        {
            var usuarioLogadoId = User.Identity.GetUserId();

            var visitante = Visitante.Criar(vm.NomeVisitante, usuarioLogadoId, 
                                        vm.DataVisita, 
                                        DateTime.Parse(vm.HoraVisita), vm.Comentario);

            unitOfWork.Visitantes.Add(visitante);
            unitOfWork.Complete();
            vm.Sucesso = true;
            vm.MeusVisitantes = unitOfWork.Visitantes.GetTodosVisitantesPorUsuario(usuarioLogadoId);

            return View("Index", vm);
        }


        public ActionResult TodosOsVisitantes()
        {
            if (!Util.Util.VerificarPerfil(User.Identity.GetUserId()))
            {
                return View("Error");
            }

            var vm = new TodosVisitantesViewModel();
            vm.De = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            vm.Ate = vm.De.AddMonths(1).AddDays(-1);
            vm.TodosVisitantes = unitOfWork.Visitantes.GetAllVisitantes();

            return View(vm);
        }
        
        public ActionResult FiltrarVisitantes(TodosVisitantesViewModel vm)
        {
            vm.TodosVisitantes = unitOfWork.Visitantes.GetAllVisitantesPorPeriodo(vm.De, vm.Ate);

            return View("TodosOsVisitantes", vm);
        }
    }
}