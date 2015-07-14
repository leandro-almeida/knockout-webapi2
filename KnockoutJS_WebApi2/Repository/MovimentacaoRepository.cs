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
            var m1 = new Movimentacao { numeroSequencial = 1, data = DateTime.Now, codigoMovimentacao = 1, descricao = "Criação de Subconta", valor = 500.0M, numeroSubconta = "20151110001", usuario = "Xico da Silva Boy", complemento = "BANCO DO BRASIL SA"};
            var m2 = new Movimentacao { numeroSequencial = 2, data = DateTime.Now, codigoMovimentacao = 3, descricao = "Emissão de Guia de Depósito", valor = 500.0M, numeroSubconta = "20151110001", usuario = "Xico da Silva Boy", complemento = "BANCO DO BRASIL SA" };
            
            var m3 = new Movimentacao { numeroSequencial = 1, data = DateTime.Now, codigoMovimentacao = 1, descricao = "Criação de Subconta", valor = 3000.0M, numeroSubconta = "20141110001", usuario = "Xico da Silva Boy", complemento = "BANCO SANTANDER SA" };
            var m4 = new Movimentacao { numeroSequencial = 2, data = DateTime.Now, codigoMovimentacao = 3, descricao = "Emissão de Guia de Depósito", valor = 3000.0M, numeroSubconta = "20141110001", usuario = "Xico da Silva Boy", complemento = "BANCO SANTANDER SA" };
            var m5 = new Movimentacao { numeroSequencial = 3, data = DateTime.Now, codigoMovimentacao = 3, descricao = "Emissão de Guia de Depósito", valor = 17000.0M, numeroSubconta = "20141110001", usuario = "Xico da Silva Boy", complemento = "BANCO ITAU SA" };
            var m6 = new Movimentacao { numeroSequencial = 4, data = DateTime.Now.AddDays(2), codigoMovimentacao = 13, descricao = "Depósito Efetuado", valor = 3000.0M, numeroSubconta = "20141110001", usuario = "Cleomarina Moura" };
            var m7 = new Movimentacao { numeroSequencial = 6, data = DateTime.Now.AddDays(2), codigoMovimentacao = 13, descricao = "Depósito Efetuado", valor = 17000.0M, numeroSubconta = "20141110001", usuario = "Cleomarina Moura" };
            var m8 = new Movimentacao { numeroSequencial = 7, data = DateTime.Now.AddDays(3), codigoMovimentacao = 7, descricao = "Pedido de Saque Total", valor = 20000.0M, numeroSubconta = "20141110001", usuario = "Xico da Silva Boy", complemento = "Maria Xica da Silva" };

            listaMovimentacao.Add(m1);
            listaMovimentacao.Add(m2);
            listaMovimentacao.Add(m3);
            listaMovimentacao.Add(m4);
            listaMovimentacao.Add(m5);
            listaMovimentacao.Add(m6);
            listaMovimentacao.Add(m7);
            listaMovimentacao.Add(m8);
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