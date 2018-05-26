using RedeSocialCondominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Persistence
{
    public interface IUnitOfWork
    {
        IMudancaRepository Mudancas { get; }
        IFuncionalidadeRepository Funcionalidades { get; }


        void Complete();
    }
}
