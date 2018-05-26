using Microsoft.AspNet.Identity;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;
using RedeSocialCondominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RedeSocialCondominio.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new Models.ApplicationDbContext());

        public HomeController() { }


        public ActionResult Index()
        {
            var usuarioId = User.Identity.GetUserId();

            var vm = new HomeViewModel()
            {
                Nome = User.Identity.Name,
                UserId = usuarioId,
                PerfilId = unitOfWork.Usuarios.GetUsuarioPorId(usuarioId).PerfilId.Value
            };
            
            return View(vm);
        }
    }
}
