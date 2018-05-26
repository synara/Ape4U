using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public Local Local { get; set; }
        public int? LocalId { get; set; }
        public DateTime? HoraExtraInicial { get; set; }
        public DateTime? HoraExtraFinal { get; set; }
        public bool IsDiaTodo { get; set; }
        public string UserId { get; set; }
        public string CorReserva { get; set; }
        
        internal static Reserva Criar(string nome, string descricao, string horaDiaInicio, string horaDiaFinal, string horaDiaExtraInicial, string horaDiaExtraFinal, int localId, string userId, string corReserva)
        {
            return new Reserva()
            {
                Nome = nome,
                Descricao = descricao,
                HoraInicio = Convert.ToDateTime(horaDiaInicio),
                HoraFim = Convert.ToDateTime(horaDiaFinal),
                HoraExtraInicial = Util.Util.ValidarHoras(horaDiaExtraInicial),
                HoraExtraFinal = Util.Util.ValidarHoras(horaDiaExtraFinal),
                LocalId = localId,
                CorReserva = corReserva,
                UserId = userId
            };
        }       
    }
}