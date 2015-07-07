using KnockoutJS_WebApi2.Models;
using KnockoutJS_WebApi2.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockoutJS_WebApi2.Controllers
{
    public class SubcontaController : ApiController
    {
        
        // GET: api/Subconta
        [HttpGet]
        public IList<Subconta> Get()
        {
            return SubcontaRepository.ObterTodos();
        }

        // GET: api/Subconta/5
        [HttpGet]
        public Subconta Get(int id)
        {
            return SubcontaRepository.ObterPorId(id);
        }

        // POST: api/Subconta
        [HttpPost]
        public void Post([FromBody]Subconta pSubconta)
        {
            SubcontaRepository.Inserir(pSubconta);
        }

        // PUT: api/Subconta/5
        [HttpPut]
        public void Put(int id, [FromBody]Subconta pSubconta)
        {
            SubcontaRepository.Alterar(pSubconta);
        }

        // DELETE: api/Subconta/5
        [HttpDelete]
        public void Delete(int id)
        {
            SubcontaRepository.Excluir(id);
        }
    }
}
