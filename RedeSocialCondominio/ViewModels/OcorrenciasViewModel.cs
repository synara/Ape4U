using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class OcorrenciasViewModel
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public bool Erro { get; internal set; }
        public string NomeUsuarioLogado { get; set; }
        public bool Sucesso { get; set; }
        public int PerfilId { get; set; }
        public List<Perfil> PerfisUsuarios { get; internal set; }

        public OcorrenciasViewModel()
        {
            PerfisUsuarios = new List<Perfil>();
        }
    }
}