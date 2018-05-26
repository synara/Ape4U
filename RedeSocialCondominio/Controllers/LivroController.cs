using RedeSocialCondominio.DTOs;
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
    public class LivroController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new Models.ApplicationDbContext());
        // GET: Livro
        public ActionResult Index()
        {
            var vm = new LivroViewModel
            {
                Postagens = unitOfWork.Posts.GetAllPosts()
            };

            return View(vm);
        }

        [HttpPost]
        public JsonResult SalvarPost(PostDTO dto)
        {
            var vm = new LivroViewModel();
           
            Post post = null;

            if (dto.Id > 0)
            {

            }
            else
            {
                post = Post.Criar(dto.Post);
                unitOfWork.Posts.Salvar(post);
                unitOfWork.Complete();
                vm.status = "Adicionado com sucesso!";
            }

            return new JsonResult { Data = new { status = vm.status } };
        }

        public JsonResult DeletePost(int id)
        {
            var post = unitOfWork.Posts.GetPostPorId(id);

            unitOfWork.Posts.Remove(post);
            unitOfWork.Complete();

            return new JsonResult { Data = new { status = "Removido com sucesso." } };
        }
    }
}