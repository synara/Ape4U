using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedeSocialCondominio.Models
{
    [Table("HorariosLocais")]
    public class HorariosLocais
    {
        public int Id { get; set; }
        public DateTime HorarioInicial { get; set; }
        public  DateTime HorarioFinal { get; set; }
        public Local Local { get; set; }
        public int LocalId { get; set; }
    }
}