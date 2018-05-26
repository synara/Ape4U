using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class LocaisViewModel
    {
        public IEnumerable<Local> Locais { get; set; }
        public string UserId { get; set; }

        public LocaisViewModel()
        {
            Locais = new List<Local>();
        }
    }
}