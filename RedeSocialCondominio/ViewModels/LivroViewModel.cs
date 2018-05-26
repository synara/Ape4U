using RedeSocialCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.ViewModels
{
    public class LivroViewModel
    {
        internal string status;

        public List<Post> Postagens { get; set; }
        public string Post { get; set; }

        public LivroViewModel()
        {
            Postagens = new List<Post>();
        }
    }
}