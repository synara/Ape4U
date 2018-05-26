using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    [Table("Perfis")]
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}