using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Mudanca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public DateTime  Hora { get; set; }
        public TipoMudanca TipoMudanca { get; set; }
        public int TipoMudancaId { get; set; }
        public string Comentario { get; set; }
        public string UsuarioId { get; set; }

        public static Mudanca Criar(string nome, DateTime data, DateTime hora, int tipo, string comentario, string usuarioId)
        {
            return new Mudanca()
            {
                Nome = nome,
                Data = data,
                Hora = hora,
                TipoMudancaId = tipo,
                Comentario = comentario, 
                UsuarioId = usuarioId
            };
        }

    }
}