using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface ILocaisRepository
    {
        IEnumerable<Local> GetAllLocais();
        Local GetLocalPorId(int id);
    }
}
