using KnockoutJS_WebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutJS_WebApi2.Repository
{
    public class MovimentacaoRepository
    {
        public static IList<Movimentacao> listaMovimentacao;

        /// <summary>
        /// Aqui construimos um retorno fixo (falso), mas deverá ser alterado para consultar o SGBD em uma aplicação real
        /// </summary>
        private static void ConstruirModelo()
        {
            listaMovimentacao = new List<Movimentacao>();

            // Movimentações fake
            var m1 = new Movimentacao { numeroSequencial = 1, data = DateTime.Now, tipo = 1, valor = 500.0M, numeroSubconta = "20151110001" };
            var m2 = new Movimentacao { numeroSequencial = 2, data = DateTime.Now, tipo = 3, valor = 500.0M, numeroSubconta = "20151110001" };
            var m3 = new Movimentacao { numeroSequencial = 1, data = DateTime.Now, tipo = 1, valor = 3000.0M, numeroSubconta = "20141110001" };
            var m4 = new Movimentacao { numeroSequencial = 2, data = DateTime.Now, tipo = 3, valor = 3000.0M, numeroSubconta = "20141110001" };

            listaMovimentacao.Add(m1);
            listaMovimentacao.Add(m2);
            listaMovimentacao.Add(m3);
            listaMovimentacao.Add(m4);
        }

        private static void VerificarLista()
        {
            if (listaMovimentacao == null)
                ConstruirModelo();
        }

        public static List<Movimentacao> ObterPorSubconta(string pNumeroSubconta)
        {
            VerificarLista();
            return listaMovimentacao.Where(f => f.numeroSubconta.Equals(pNumeroSubconta.ToString())).ToList();
        }

        public static void Inserir(Movimentacao pMovimentacao)
        {
            VerificarLista();
            listaMovimentacao.Add(pMovimentacao);
        }

        public static void Alterar(Movimentacao pMovimentacao)
        {
            VerificarLista();
            Movimentacao m = listaMovimentacao.FirstOrDefault(f => f.numeroSubconta == pMovimentacao.numeroSubconta && f.numeroSequencial == pMovimentacao.numeroSequencial);
            if (m != null)
            {
                var index = listaMovimentacao.IndexOf(m);
                listaMovimentacao.RemoveAt(index);
                listaMovimentacao.Insert(index, pMovimentacao);
            }
        }

        public static void Excluir(Movimentacao pMovimentacao)
        {
            VerificarLista();
            Movimentacao m = listaMovimentacao.FirstOrDefault(f => f.numeroSubconta == pMovimentacao.numeroSubconta && f.numeroSequencial == pMovimentacao.numeroSequencial);
            if (m != null)
            {
                listaMovimentacao.Remove(m);
            }
        }
    }
}