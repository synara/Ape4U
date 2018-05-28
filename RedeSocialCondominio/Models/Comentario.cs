using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public DateTime DataHoraComentario { get; set; }
        public string UsuarioId { get; set; }
        public string NomeUsuarioQuePostou { get; set; }

        public static Comentario Criar(string comentario, int postId, string usuarioID, string nomeUsuario)
        {
            return new Comentario()
            {
                Comment = comentario,
                PostId = postId,
                DataHoraComentario = DateTime.Now,
                UsuarioId = usuarioID,
                NomeUsuarioQuePostou = nomeUsuario
            };
        }
    }
}