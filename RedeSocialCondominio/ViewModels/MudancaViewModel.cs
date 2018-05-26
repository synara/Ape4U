using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class MudancaViewModel
    {
        public string NomeUsuarioLogado { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Dia { get; set; }
        public string Hora { get; set; }
        public int TipoMudancaId { get; set; }
        public string Email { get; set; }
        public string Comentario { get; set; }
        public string MensagemDeErro { get; set; }
        public bool ErrorValidacao { get; set; }
        public IEnumerable<TipoMudanca> TiposMudanca { get; set; }
        public bool Sucesso { get; set; }
        public bool ErrorMudanca { get; set; }
        public List<Mudanca> MinhasMudancas { get; internal set; }

        public MudancaViewModel()
        {
            Sucesso = false;
            ErrorValidacao = false;
            ErrorMudanca = false;
            TiposMudanca = new List<TipoMudanca>();
        }
    }
}