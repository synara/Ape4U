using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class HomeViewModel
    {
        public string Nome { get; set; }
        public string UserId { get; internal set; }
        public int PerfilId { get; set; }
    }
}