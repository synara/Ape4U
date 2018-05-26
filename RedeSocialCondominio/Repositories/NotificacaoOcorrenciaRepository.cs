using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class NotificacaoOcorrenciaRepository : INotificacaoOcorrenciaRepository
    {
        private ApplicationDbContext _ctx;

        public NotificacaoOcorrenciaRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Salvar(NotificacaoOcorrencia ocorrencia)
        {
            _ctx.NotificacaoOcorrencia.Add(ocorrencia);
        }
    }
}