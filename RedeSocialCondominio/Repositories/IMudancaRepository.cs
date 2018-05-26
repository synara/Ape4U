using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IMudancaRepository
    {
        List<Mudanca> GetAllMudancas();
        Mudanca GetMudancaPorData(DateTime data);
        void Add(Mudanca mudanca);
        List<Mudanca> GetMudancasPorId(string id);
    }
}
