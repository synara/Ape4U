using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IComentariosRepository
    {
        List<Comentario> GetAllComentariosPorPostId(int postId);
        List<Comentario> GetAllComentarios();
        void Add(Comentario comentario);
        void Remove(Comentario comentario);
    }
}
