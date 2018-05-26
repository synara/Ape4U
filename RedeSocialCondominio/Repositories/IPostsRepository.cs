using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialCondominio.Repositories
{
    public interface IPostsRepository
    {
        void Salvar(Post post);
        List<Post> GetAllPosts();
        Post GetPostPorId(int id);
        void Remove(Post post);
    }
}
