using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class TodosVisitantesViewModel
    {
        public IEnumerable<Visitante> TodosVisitantes { get; set; }
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }

        public TodosVisitantesViewModel()
        {
            TodosVisitantes = new List<Visitante>();
        }
    }
}