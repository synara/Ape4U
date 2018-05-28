using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface INotificacaoMudancaRepository
    {
        void Salvar(NotificacaoMudanca mudanca);
    }
}
