using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.DTOs
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Comentario { get; set; }
    }
}