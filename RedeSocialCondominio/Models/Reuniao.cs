using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    [Table("Reunioes")]
    public class Reuniao
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime Dia { get; set; }
        public string UsuarioId { get; set; }


        public static Reuniao Criar(string assunto, string descricao, DateTime horaInicio, DateTime horaFim, DateTime dia, string usuarioId)
        {
            return new Reuniao
            {
                Assunto = assunto,
                Descricao = descricao,
                Dia = dia,
                HoraInicio = Convert.ToDateTime(horaInicio),
                HoraFim = Convert.ToDateTime(horaFim),
                UsuarioId = usuarioId
            };
        }
    }
}