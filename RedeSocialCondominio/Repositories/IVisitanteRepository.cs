using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Repositories
{
    public interface IVisitanteRepository
    {
        IEnumerable<Visitante> GetTodosVisitantesPorUsuario(string id);
        void Add(Visitante visitante);
        IEnumerable<Visitante> GetAllVisitantes();
        IEnumerable<Visitante> GetAllVisitantesPorPeriodo(DateTime de, DateTime ate);
    }
}