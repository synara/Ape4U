using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class FuncionalidadesViewModel
    {
        public IEnumerable<Funcionalidade> Funcionalidades { get; set; }
        public IEnumerable<TipoMudanca> TiposMudanca { get; set; }
        public int TipoPerfilId { get; set; }
        public int MyProperty { get; set; }
        public Usuarios Usuario { get; set; }

        public FuncionalidadesViewModel()
        {
            Funcionalidades = new List<Funcionalidade>();
            TiposMudanca = new List<TipoMudanca>();
        }
    }
}