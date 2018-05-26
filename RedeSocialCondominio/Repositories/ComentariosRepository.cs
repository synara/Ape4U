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

        public List<Comentario> GetAllComentariosPorPostId(int postId)
        {
            return _ctx.Comentarios.Where(c => c.PostId == postId).ToList();
        }
    }
}