using Microsoft.AspNet.Identity;
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
                Postagens = unitOfWork.Posts.GetAllPosts(),
                Comentarios = unitOfWork.Comentarios.GetAllComentarios(),
                NomeUsuarioLogado = User.Identity.Name
            };

            return View(vm);
        }

        [HttpPost]
        public JsonResult SalvarPost(PostDTO dto)
        {
            string status = null;
            Post post = null;

            if (dto.Id > 0)
            {

            }
            else
            {
                post = Post.Criar(dto.Post, User.Identity.GetUserId(), User.Identity.Name);
                unitOfWork.Posts.Salvar(post);
                unitOfWork.Complete();
                status = "Adicionado com sucesso!";
            }

            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult DeletePost(int id)
        {
            var post = unitOfWork.Posts.GetPostPorId(id);

            unitOfWork.Posts.Remove(post);
            unitOfWork.Complete();

            return new JsonResult { Data = new { status = "Removido com sucesso." } };
        }

        public JsonResult SalvarComentario(ComentarioDTO dto)
        {
            string status = null;
            Comentario comentario = null;

            if (dto.Id > 0)
            {

            }
            else
            {
                comentario = Comentario.Criar(dto.Comentario, dto.PostId, User.Identity.GetUserId(), User.Identity.Name);
                unitOfWork.Comentarios.Add(comentario);
                unitOfWork.Complete();
                status = "Comentário postado!";
            }

            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult DeleteComentario(int id)
        {
            var comentario = unitOfWork.Comentarios.GetAllComentarios().Where(p => p.Id == id).FirstOrDefault();

            unitOfWork.Comentarios.Remove(comentario);
            unitOfWork.Complete();

            return new JsonResult { Data = new { status = "Removido com sucesso." } };
        }
    }
}