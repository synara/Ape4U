using RedeSocialCondominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RedeSocialCondominio.Models
{
    [Table("Ocorrencias")]
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }


        public static Ocorrencia Criar(string assunto, string descricao)
        {
            return new Ocorrencia()
            {
                Assunto = assunto,
                Descricao = descricao,
            };
        }
    }
}