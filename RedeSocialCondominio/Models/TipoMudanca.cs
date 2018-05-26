using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    [Table("TiposMudanca")]
    public class TipoMudanca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}