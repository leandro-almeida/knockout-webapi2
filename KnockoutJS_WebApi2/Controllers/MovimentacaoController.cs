using KnockoutJS_WebApi2.Models;
using KnockoutJS_WebApi2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockoutJS_WebApi2.Controllers
{
    public class MovimentacaoController : ApiController
    {
        // GET: api/Movimentacao
        [HttpGet]
        public IList<Movimentacao> Get()
        {
            throw new NotSupportedException("Não é possível obter lista de todas as movimentações de subcontas sem especificar parâmetros.");
        }

        // GET: api/Movimentacao/numeroSubconta
        [HttpGet]
        public Movimentacao Get(string pNumeroSubconta)
        {
            return MovimentacaoRepository.ObterPorSubconta(pNumeroSubconta);
        }

        // POST: api/Movimentacao
        [HttpPost]
        public void Post([FromBody]Movimentacao pMovimentacao)
        {
            MovimentacaoRepository.Inserir(pMovimentacao);
        }

        // PUT: api/Movimentacao
        [HttpPut]
        public void Put([FromBody]Movimentacao pMovimentacao)
        {
            MovimentacaoRepository.Alterar(pMovimentacao);
        }

        // DELETE: api/Movimentacao
        [HttpDelete]
        public void Delete([FromBody]Movimentacao pMovimentacao)
        {
            MovimentacaoRepository.Excluir(pMovimentacao);
        }
    }
}
