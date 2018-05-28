using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        private ApplicationDbContext _ctx;

        public ComentariosRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Comentario comentario)
        {
            _ctx.Comentarios.Add(comentario);
        }

        public List<Comentario> GetAllComentarios()
        {
            return _ctx.Comentarios.OrderBy(c => c.DataHoraComentario).ToList();
        }

        public List<Comentario> GetAllComentariosPorPostId(int postId)
        {
            return _ctx.Comentarios.Where(c => c.PostId == postId).ToList();
        }

        public void Remove(Comentario comentario)
        {
            _ctx.Comentarios.Remove(comentario);
        }
    }
}