using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class OcorrenciasRepository : IOcorrenciasRepository
    {
        ApplicationDbContext _ctx;

        public OcorrenciasRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Ocorrencia> GetAllOcorrencias()
        {
            return _ctx.Ocorrencias.ToList();
        }

        public void Salvar(Ocorrencia ocorrencia)
        {
            _ctx.Ocorrencias.Add(ocorrencia);
        }
    }
}