using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public string NomeVisitante { get; set; }
        public DateTime Dia { get; set; }
        public DateTime Hora { get; set; }
        public string UsuarioId { get; set; }

        public static Horario Criar(string nomeVisitante, DateTime dia, DateTime hora, string usuarioId)
        {
            return new Horario()
            {
                NomeVisitante = nomeVisitante,
                Dia = dia,
                Hora = hora,
                UsuarioId = usuarioId
            };
        }
    }
}