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
    public class ReuniaoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public ActionResult Index()
        {
            var vm = new ReuniaoViewModel();
            var nomeUsuario = User.Identity.Name;
            vm.NomeUsuarioLogado = nomeUsuario.Split('-')[0];
            vm.Dia = DateTime.Now.ToLocalTime();
            vm.HoraInicio = DateTime.Now;
            vm.HoraFim = DateTime.Now.AddHours(1);
            return View(vm);
        }

        public ActionResult AgendarReuniao(ReuniaoViewModel vm)
        {
            var validacao = Util.Util.ValidarReuniao(vm);

            if (string.IsNullOrEmpty(validacao))
            {
                var reuniao = Reuniao.Criar(vm.Assunto, vm.Descricao, vm.HoraInicio, vm.HoraFim, vm.Dia, User.Identity.GetUserId());
                unitOfWork.Reunioes.Salvar(reuniao);
                unitOfWork.Complete();
                NotificarReuniao(reuniao);
                vm.Sucesso = true;
                vm.Erro = false;
            }
            else
            {
                vm.Mensagem = validacao;
                vm.Erro = true;
            }

            return View("Index", vm);
        }

        public void NotificarReuniao(Reuniao reuniao)
        {
            var notificacao = Notificacao.NotificarReuniao(reuniao);
            unitOfWork.Notificacoes.Add(notificacao);
            unitOfWork.Complete();

            var notificacaoReuniao = NotificacaoReuniao.Criar(reuniao.Id, notificacao.Id);
            unitOfWork.NotificacaoReuniao.Add(notificacaoReuniao);
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
