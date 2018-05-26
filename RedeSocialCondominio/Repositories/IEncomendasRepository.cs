using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IEncomendasRepository
    {
        void Complete(Encomenda encomenda);
        IEnumerable<Encomenda> GetAllEncomendas();
        IEnumerable<Encomenda> GetEncomendasPorPeriodo(DateTime de, DateTime ate);
        Encomenda GetEncomendaPorId(int id);
    }
}
