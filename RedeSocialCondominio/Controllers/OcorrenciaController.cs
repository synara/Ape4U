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
    public class OcorrenciaController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new Models.ApplicationDbContext());
        // GET: Ocorrencia
        public ActionResult Index()
        {
            var vm = new OcorrenciasViewModel();
            var nomeUsuario = User.Identity.Name;
            vm.NomeUsuarioLogado = nomeUsuario.Split('-')[0];
            vm.PerfisUsuarios = unitOfWork.PerfisUsuario.PerfisUsuario();
            return View(vm);
        }

        [HttpPost]
        public ActionResult RegistrarOcorrencia(OcorrenciasViewModel vm)
        {
            var mensagem = Util.Util.ValidarOcorrencia(vm);
            Ocorrencia ocorrencia = null;

            if (string.IsNullOrEmpty(mensagem))
            {
                var nomeUsuario = User.Identity.Name;
                ocorrencia = Ocorrencia.Criar(vm.Assunto, vm.Descricao);
                unitOfWork.Ocorrencias.Salvar(ocorrencia);
                unitOfWork.Complete();
                vm.NomeUsuarioLogado = nomeUsuario.Split('-')[0];
                vm.Sucesso = true;
                NotificarOcorrencia(ocorrencia, vm.PerfilId);
            }

            else
                vm.Erro = true;

            return View("Index", vm);
        }

        private void NotificarOcorrencia(Ocorrencia o, int perfilId)
        {
            var notificacao = Notificacao.NotificarOcorrencia(o, perfilId);

            unitOfWork.Notificacoes.Add(notificacao);
            unitOfWork.Complete();

            var notificarOcorrencia = NotificacaoOcorrencia.Criar(o.Id, notificacao.Id);
            unitOfWork.NotificacaoOcorrencia.Salvar(notificarOcorrencia);
            unitOfWork.Complete();

            var usuarios = unitOfWork.Usuarios.GetAllUsuarios();
            var usuariosPorPerfilId = usuarios.Where(p => p.PerfilId == perfilId).ToList();

            if (perfilId == 0) ArmazenarNotificacoesUsuarios(notificacao, usuarios);
            else ArmazenarNotificacoesUsuarios(notificacao, usuariosPorPerfilId);

        }

        private void ArmazenarNotificacoesUsuarios(Notificacao notificacao, List<Usuarios> usuarios)
        {
            foreach (var u in usuarios)
            {
                var usuarioNotificacao = UsuarioNotificacao.Criar(notificacao, u.UsuarioId, DateTime.Now);
                unitOfWork.UsuariosNotificacao.Add(usuarioNotificacao);
                unitOfWork.Complete();
            }
        }
    }
}