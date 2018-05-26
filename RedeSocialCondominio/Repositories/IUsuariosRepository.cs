using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IUsuariosRepository
    {
        void Complete(Usuarios usuario);
        Usuarios GetUsuario(int id);
        Usuarios GetUsuarioPorId(string usuarioLogadoId);
        List<Usuarios> GetAllUsuarios();
    }
}
