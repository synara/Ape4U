using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class LivroViewModel
    {
        public List<Post> Postagens { get; set; }
        public string Post { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public int PostId { get; set; }
        public string NomeUsuarioLogado { get; set; }

        public LivroViewModel()
        {
            Postagens = new List<Post>();
            Comentarios = new List<Comentario>();
        }
    }
}