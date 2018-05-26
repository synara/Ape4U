using RedeSocialCondominio.Models;
using RedeSocialCondominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _ctx;

        public IMudancaRepository Mudancas { get; private set; }

        public IFuncionalidadeRepository Funcionalidades { get; private set; }

        public ITipoMudancaRepository TiposMudanca { get; private set; }

        public IUsuariosRepository Usuarios { get; set; }

        public IVisitanteRepository Visitantes { get; set; }

        public IEncomendasRepository Encomendas { get; set; }

        public IHorariosRepository Horarios { get; set; }

        public IReservasRepository Reservas { get; set; }

        public ILocaisRepository Locais { get; set; }

        public IHorariosLocaisRepository HorariosLocais { get; set; }

        public IOcorrenciasRepository Ocorrencias { get; set; }

        public INotificacoesRepository Notificacoes { get; set; }

        public IUsuariosNotificacao UsuariosNotificacao { get; set; }

        public INotificacaoReservaRepository NotificacaoReserva { get; set; }

        public INotificacaoOcorrenciaRepository NotificacaoOcorrencia { get; set; }

        public IPerfilRepository PerfisUsuario { get; set; }

        public IReunioesRepository Reunioes { get; set; }

        public  INotificacaoReuniaoRepository NotificacaoReuniao { get; set; }

        public INotificacaoEncomendaRepository NotificacaoEncomenda { get; set; }

        public IPostsRepository Posts { get; set; }

        public IComentariosRepository Comentarios { get; set; }

        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            Mudancas = new MudancaRepository(_ctx);
            Funcionalidades = new FuncionalidadeRepository(_ctx);
            TiposMudanca = new TiposMudancaRepository(_ctx);
            Usuarios = new UsuariosRepository(_ctx);
            Visitantes = new VisitanteRepository(_ctx);
            Encomendas = new EncomendasRepository(_ctx);
            Horarios = new HorariosRepository(_ctx);
            Reservas = new ReservaRepository(_ctx);
            Locais = new LocaisRepository(_ctx);
            HorariosLocais = new HorariosLocaisRepository(_ctx);
            Notificacoes = new NotificacoesRepository(_ctx);
            Ocorrencias = new OcorrenciasRepository(_ctx);
            NotificacaoReserva = new NotificacaoReservaRepository(_ctx);
            UsuariosNotificacao = new UsuarioNotificacaoRepository(_ctx);
            NotificacaoOcorrencia = new NotificacaoOcorrenciaRepository(_ctx);
            PerfisUsuario = new PerfilRepository(_ctx);
            Reunioes = new ReunioesRepository(_ctx);
            NotificacaoReuniao = new NotificacaoReuniaoRepository(_ctx);
            NotificacaoEncomenda = new NotificacaoEncomendaRepository(_ctx);
            Posts = new PostsRepository(_ctx);
            Comentarios = new ComentariosRepository(_ctx);
        }

        public void Complete()
        {
            this._ctx.SaveChanges();
        }
    }
}