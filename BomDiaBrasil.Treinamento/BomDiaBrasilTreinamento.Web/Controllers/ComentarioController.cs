﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BomDiaBrasilTreinamento.Web.Controllers
{
    public class ComentarioController : ApiController
    {
        // GET: api/Comentario
        public IEnumerable<string> Get()
        {
            return new string[] { "Márcio", "Abrantes" };
        }

        // GET: api/Comentario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comentario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Comentario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comentario/5
        public void Delete(int id)
        {
        }
    }
}
