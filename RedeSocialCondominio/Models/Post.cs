using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Postagem { get; set; }
        public DateTime DataHoraPostagem { get; set; }
        [NotMapped]
        public List<Comentario> Comentarios { get; set; }

        public static Post Criar(string postagem)
        {
            return new Post()
            {
                DataHoraPostagem = DateTime.Now,
                Postagem = postagem
            };
        }

    }
}