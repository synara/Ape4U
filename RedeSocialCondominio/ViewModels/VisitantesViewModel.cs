using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class VisitantesViewModel
    {
        public string NomeUsuarioLogado { get; set; }
        public string NomeVisitante { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVisita { get; set; }
        public string HoraVisita { get; set; }
        public string Comentario { get; set; }
        public IEnumerable<Visitante> MeusVisitantes { get; set; }
        public bool Sucesso { get; internal set; }

        public VisitantesViewModel()
        {
            MeusVisitantes = new List<Visitante>();
        }

    }
}