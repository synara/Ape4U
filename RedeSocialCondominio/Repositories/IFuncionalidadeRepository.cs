using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IFuncionalidadeRepository
    {
        IEnumerable<Funcionalidade> GetAllFuncionalidades();
        IEnumerable<Funcionalidade> GetAllFuncionalidadesPorPerfil(int perfilId);
    }
}
