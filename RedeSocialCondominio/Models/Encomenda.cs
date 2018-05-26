using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class Encomenda
    {
        public int Id { get; set; }
        public string NomeEncomenda { get; set; }
        public string NomeResponsavel { get; set; }
        public Usuarios Usuario { get; set; }
        public string UsuarioId { get; set; }
        public string NomeQuemRecebeu { get; set; }
        public DateTime DataHoraEntrega { get; set; }
        public string DescricaoEncomenda { get; set; }
        public bool Fragil { get; set; }
        public bool Entregue { get; set; }
        public DateTime? HoraRecebida { get; set; }


        public static Encomenda Criar(string descricao, bool fragil, string responsavel, string usuarioId)
        {
            return new Encomenda()
            {
                DescricaoEncomenda = descricao,
                Fragil = fragil,
                NomeResponsavel = responsavel,
                UsuarioId = usuarioId,
                DataHoraEntrega = DateTime.Now,
                Entregue  = false
            };
        }
    }
}