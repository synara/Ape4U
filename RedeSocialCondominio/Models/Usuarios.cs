using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public int? PerfilId { get; set; }
        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }

    }
}