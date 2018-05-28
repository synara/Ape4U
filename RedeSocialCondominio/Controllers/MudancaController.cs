using Microsoft.AspNet.Identity;
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
    public class MudancaController : Controller
    {
        // GET: Mudanca
        private UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public ActionResult Index()
        {
            var vm = new MudancaViewModel();
            var nomeUsuario = User.Identity.Name;
            vm.NomeUsuarioLogado = nomeUsuario.Split('-')[0];
            vm.ErrorValidacao = false;
            vm.Dia = DateTime.Now;
            vm.Hora = DateTime.Now.ToString("HH:mm");
            vm.TiposMudanca = unitOfWork.TiposMudanca.GetAllTiposMudanca();
            vm.MinhasMudancas = unitOfWork.Mudancas.GetMudancasPorId(User.Identity.GetUserId());

            return View(vm);
        }

        [HttpPost]
        public ActionResult RegistrarMudanca(MudancaViewModel vm)
        {
            Mudanca mudanca = new Mudanca();
            var validacao = Util.Util.ValidarCamposMudanca(vm);
            
            var hora = DateTime.Parse(vm.Hora);
            var data = vm.Dia;
            var mudancaNoDia = unitOfWork.Mudancas.GetMudancaPorData(data);
            
            if (!validacao && mudancaNoDia == null)
            {
                mudanca = Mudanca.Criar(vm.Nome, data, hora, vm.TipoMudancaId, vm.Comentario, User.Identity.GetUserId());
                unitOfWork.Mudancas.Add(mudanca);
                unitOfWork.Complete();
                vm.Sucesso = true;
                NotificarMudanca(mudanca);
            }

            if (mudancaNoDia != null) vm.ErrorMudanca = true;
            if(validacao) vm.ErrorValidacao = true;


            vm.TiposMudanca = unitOfWork.TiposMudanca.GetAllTiposMudanca();
            vm.MinhasMudancas = unitOfWork.Mudancas.GetMudancasPorId(User.Identity.GetUserId());   

            return View("Index", vm);
        }

        public void NotificarMudanca(Mudanca mudanca)
        {
            var tipoMudanca = unitOfWork.TiposMudanca.GetAllTiposMudanca().Where(p => p.Id == mudanca.TipoMudancaId).FirstOrDefault().Descricao;
            var notificacao = Notificacao.NotificarMudanca(mudanca, tipoMudanca);
            unitOfWork.Notificacoes.Add(notificacao);
            unitOfWork.Complete();

            var notificacaoMudanca = NotificacaoMudanca.Criar(notificacao.Id, mudanca.Id);
            unitOfWork.NotificacaoMudanca.Salvar(notificacaoMudanca);
            unitOfWork.Complete();

            var usuarios = unitOfWork.Usuarios.GetAllUsuarios();

            foreach (var u in usuarios)
            {
                var usuarioNotificacao = UsuarioNotificacao.Criar(notificacao, u.UsuarioId, DateTime.Now);
                unitOfWork.UsuariosNotificacao.Add(usuarioNotificacao);
                unitOfWork.Complete();
            }
        }

    }
}