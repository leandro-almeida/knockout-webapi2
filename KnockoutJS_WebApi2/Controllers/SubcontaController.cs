using KnockoutJS_WebApi2.Models;
using KnockoutJS_WebApi2.Repository;
using System.Collections.Generic;
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

        // GET: api/Subconta/id
        [HttpGet]
        public Subconta Get(int id)
        {
            return SubcontaRepository.ObterPorId(id);
        }

        // GET: api/Subconta/
        [HttpGet]
        [Route("api/Subconta/{subconta}/{processo?}/{titular}")]
        public IList<Subconta> Get(string subconta, string processo, string titular)
        {
            // 1 param: subconta ou processo ou titular
            // 2 params: subconta/processo
            // subconta / processo / titular
            return SubcontaRepository.ObterPorParametros(subconta, processo, titular);
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
