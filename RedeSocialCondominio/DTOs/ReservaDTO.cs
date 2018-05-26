using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string HoraDiaInicio { get; set; }
        public string HoraDiaFinal { get; set; }
        public string HoraDiaExtraInicial { get; set; }
        public string HoraDiaExtraFinal { get; set; }
        public bool isDiaTodo { get; set; }
        public string LocalNome { get; set; }
        public int LocalId { get; set; }
        public string CorReserva { get; set; }
        public string Mensagem { get; set; }
    }
}