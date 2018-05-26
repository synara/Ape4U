using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private ApplicationDbContext _ctx;

        public UsuariosRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Complete(Usuarios usuario)
        {
            _ctx.Usuarios.Add(usuario);
        }

        public Usuarios GetUsuario(int id)
        {
            return _ctx.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public Usuarios GetUsuarioPorId(string usuarioLogadoId)
        {
            return _ctx.Usuarios.Where(u => u.UsuarioId == usuarioLogadoId).FirstOrDefault();
        }

        public List<Usuarios> GetAllUsuarios()
        {
            return _ctx.Usuarios.ToList();
        }
    }
}