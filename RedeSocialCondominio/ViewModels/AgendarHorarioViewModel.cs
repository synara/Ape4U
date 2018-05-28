using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class AgendarHorarioViewModel
    {
        public string Nome { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Dia { get; set; }
        public string Hora { get; set; }
        public string VisitanteNome { get; set; }
        public string UsuarioLogado { get; set; }
        public bool Falhou { get; internal set; }
        public bool Agendou { get; internal set; }
        public IEnumerable<Horario> Horarios { get; set; }

        public AgendarHorarioViewModel()
        {
            Horarios = new List<Horario>();
        }

    }
}