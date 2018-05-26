using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class TodasAsEncomendasViewModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime De { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Ate { get; set; }
        public IEnumerable<Encomenda> Encomendas { get; set; }

        public TodasAsEncomendasViewModel()
        {
            Encomendas = new List<Encomenda>();
        }
    }
}