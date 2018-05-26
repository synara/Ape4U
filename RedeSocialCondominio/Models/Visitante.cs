using RedeSocialCondominio.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace RedeSocialCondominio.Models
{
    public class Visitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UsuarioId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DiaVisita { get; set; }
        public DateTime HoraVisita { get; set; }
        public string Comentario { get; set; }



        public static Visitante Criar(string nome, string usuarioId, DateTime diaVisita, DateTime horaVisita, string comentario)
        {
            return new Visitante()
            {
                Nome = nome,
                UsuarioId = usuarioId,
                DiaVisita = diaVisita,
                HoraVisita = horaVisita,
                Comentario = comentario
            };
        }

    }

}