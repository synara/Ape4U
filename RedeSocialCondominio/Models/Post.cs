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
        public string UsuarioId { get; set; }
        public string NomeUsuarioQuePostou { get; set; }

        public static Post Criar(string postagem, string usuarioId, string nomeUsuario)
        {
            return new Post()
            {
                DataHoraPostagem = DateTime.Now,
                Postagem = postagem,
                UsuarioId = usuarioId,
                NomeUsuarioQuePostou = nomeUsuario
            };
        }

    }
}