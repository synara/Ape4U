using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedeSocialCondominio.Models;

namespace RedeSocialCondominio.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private ApplicationDbContext _ctx;

        public PostsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.OrderByDescending(p=>p.DataHoraPostagem).ToList();
        }

        public Post GetPostPorId(int id)
        {
            return _ctx.Posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Remove(Post post)
        {
            _ctx.Posts.Remove(post);
        }

        public void Salvar(Post post)
        {
            _ctx.Posts.Add(post);
        }
    }
}