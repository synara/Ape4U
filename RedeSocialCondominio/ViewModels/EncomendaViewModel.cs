using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class EncomendaViewModel
    {
        public string NomeUsuarioLogado { get; set; }
        public string Descricao { get; set; }
        public string NomeResponsavel { get; set; }
        public bool Fragil { get; set; }
        public bool Sucesso { get; internal set; }

        public EncomendaViewModel()
        {
            Sucesso = false;
        }
    }
}