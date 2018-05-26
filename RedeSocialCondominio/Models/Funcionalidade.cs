using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Funcionalidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Perfil Perfil { get; set; }
        public int? PerfilId { get; set; }
    }
}