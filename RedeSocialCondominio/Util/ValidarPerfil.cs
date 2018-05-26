using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Util
{
    public class ValidarPerfil : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var moradorId = Convert.ToInt32(ConfigurationManager.AppSettings["MoradorId"]);
            var funcionarioId = Convert.ToInt32(ConfigurationManager.AppSettings["FuncionarioId"]);
            var perfilId = Convert.ToInt32(value);
            var autorizado = false;

            if(perfilId == moradorId || perfilId == funcionarioId)
            {
                autorizado = true;
            }

            return autorizado;

        }
    }
}