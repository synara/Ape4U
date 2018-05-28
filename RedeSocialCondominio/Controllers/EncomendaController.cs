using Microsoft.AspNet.Identity;
using RedeSocialCondominio.DTOs;
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
    public class EncomendaController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        // GET: Encomenda
        public ActionResult Index()
        {
            var vm = new EncomendaViewModel();
            var nomeUsuario = User.Identity.Name;
            vm.NomeUsuarioLogado = nomeUsuario.Split('-')[0];

            return View(vm);
        }

        [HttpPost]
        public ActionResult RegistrarEncomenda(EncomendaViewModel vm)
        {
            var encomenda = Encomenda.Criar(vm.Descricao, vm.Fragil, vm.NomeResponsavel, User.Identity.GetUserId());
            unitOfWork.Encomendas.Complete(encomenda);
            unitOfWork.Complete();
            vm.Sucesso = true;
            NotificarEncomenda(encomenda);

            return View("Index", vm);
        }

        private void NotificarEncomenda(Encomenda encomenda)
        {
            var notificacao = Notificacao.NotificarEncomendaRecebida(encomenda);
            unitOfWork.Notificacoes.Add(notificacao);
            unitOfWork.Complete();

            var notificacaoEncomenda = NotificacaoEncomenda.Criar(notificacao.Id, encomenda.Id);
            unitOfWork.NotificacaoEncomenda.Salvar(notificacaoEncomenda);
            unitOfWork.Complete();

            var usuarios = unitOfWork.Usuarios.GetAllUsuarios().Where(u => u.PerfilId == 2 || u.PerfilId == 3).ToList();

            foreach (var u in usuarios)
            {
                var usuarioNotificacao = UsuarioNotificacao.Criar(notificacao, u.UsuarioId, DateTime.Now);
                unitOfWork.UsuariosNotificacao.Add(usuarioNotificacao);
                unitOfWork.Complete();
            }
        }

        [HttpGet]
        public ActionResult TodasEncomendas()
        {

            if (!Util.Util.VerificarPerfil(User.Identity.GetUserId()))
            {
                return View("Error");
            }

            var vm = new TodasAsEncomendasViewModel();
            vm.De = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date;
            vm.Ate = vm.De.AddMonths(1).AddDays(-1).Date;
            vm.Encomendas = unitOfWork.Encomendas.GetAllEncomendas();

            return View(vm);
        }

        public ActionResult FiltrarEncomendas(TodasAsEncomendasViewModel vm)
        {
            vm.Encomendas = 
                unitOfWork.Encomendas.GetEncomendasPorPeriodo(vm.De, vm.Ate);

            return View("TodasEncomendas", vm);
        }

        public ActionResult EncomendaRecebida(int encomendaId)
        {
            var encomenda = unitOfWork.Encomendas.GetEncomendaPorId(encomendaId);
            encomenda.Entregue = true;
            encomenda.NomeQuemRecebeu = User.Identity.Name;
            encomenda.HoraRecebida = DateTime.Now;
            unitOfWork.Complete();
            NotificarEncomendaRecebida(encomenda);
            var vm = new TodasAsEncomendasViewModel().Encomendas = unitOfWork.Encomendas.GetAllEncomendas();

            return View("TodasEncomendas", vm);
        }

        public void NotificarEncomendaRecebida(Encomenda encomenda)
        {
            var notificacao = Notificacao.NotificarEncomendaRecebida(encomenda);
            unitOfWork.Notificacoes.Add(notificacao);
            unitOfWork.Complete();

            var notificacaoEncomenda = NotificacaoEncomenda.Criar(notificacao.Id, encomenda.Id);
            unitOfWork.NotificacaoEncomenda.Salvar(notificacaoEncomenda);
            unitOfWork.Complete();

            var usuarioNotificacao = UsuarioNotificacao.Criar(notificacao, encomenda.UsuarioId, DateTime.Now);
            unitOfWork.UsuariosNotificacao.Add(usuarioNotificacao);
            unitOfWork.Complete();
        }

        public JsonResult AdicionarObservacao(ObservacaoDTO dto)
        {
            string status = null;
            var encomenda = unitOfWork.Encomendas.GetEncomendaPorId(dto.Id);
            encomenda.DescricaoEncomenda += "\n" + dto.Observacao;
            unitOfWork.Complete();
            status = "Observação adicionada!";

            var vm = new TodasAsEncomendasViewModel()
            {
                Encomendas = unitOfWork.Encomendas.GetAllEncomendas()
            };

            return new JsonResult { Data = new { status = status } };
        }
    }
}