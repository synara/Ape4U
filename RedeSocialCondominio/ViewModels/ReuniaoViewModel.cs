using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RedeSocialCondominio.ViewModels
{
    public class ReuniaoViewModel
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraInicio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraFim { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Dia { get; set; }
        public bool Sucesso { get; internal set; }
        public string Mensagem { get; internal set; }
        public bool Erro { get; set; }
        public string NomeUsuarioLogado { get; set; }

        public ReuniaoViewModel()
        {
            Sucesso = false;
            Erro = false;
        }
    }
}