using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedeSocialCondominio.Controllers.API
{
    public class AcoesEncomendaController : ApiController
    {
        public IHttpActionResult EncomendaRecebida(int encomendaId)
        {

            return Ok();
        }
    }
}
