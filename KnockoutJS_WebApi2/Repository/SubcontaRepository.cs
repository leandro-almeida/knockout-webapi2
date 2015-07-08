using KnockoutJS_WebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutJS_WebApi2.Repository
{
    public class SubcontaRepository
    {

        public static IList<Subconta> listaSubcontas = null;

        /// <summary>
        /// Aqui construimos um retorno fixo (falso), mas deverá ser alterado para consultar o SGBD em uma aplicação real
        /// </summary>
        private static void ConstruirModelo()
        {
            listaSubcontas = new List<Subconta>();

            // Subcontas fake
            var s1 = new Subconta { id = 1, numeroSubconta = "20151110001", numeroProcesso = "NNNNNNN-DD.2015.8.14.O3O1", titular = "Xico da Silva Boy 2015", saldo = 2500M, dataAbertura = DateTime.Today };
            var s2 = new Subconta { id = 2, numeroSubconta = "20141110001", numeroProcesso = "NNNNNNN-DD.2014.8.14.O3O1", titular = "Xico da Silva Boy 2014", saldo = 20000000M, dataAbertura = DateTime.Today.AddYears(-1) };
            
            // Adiciona objetos
            listaSubcontas.Add(s1);
            listaSubcontas.Add(s2);
        }
        
        private static void VerificarLista() {
            if (listaSubcontas == null)
                ConstruirModelo();
        }

        public static IList<Subconta> ObterTodos()
        {
            VerificarLista();
            return listaSubcontas;
        }

        public static Subconta ObterPorId(int id)
        {
            VerificarLista();
            return listaSubcontas.FirstOrDefault(f => f.id == id);
        }

        public static void Inserir(Subconta pSubconta)
        {
            VerificarLista();
            listaSubcontas.Add(pSubconta);
        }

        public static void Alterar(Subconta pSubconta)
        {
            VerificarLista();
            Subconta s = listaSubcontas.FirstOrDefault(f => f.id == pSubconta.id);
            if (s != null)
            {
                var index = listaSubcontas.IndexOf(s);
                listaSubcontas.RemoveAt(index);
                listaSubcontas.Insert(index, pSubconta);
            }
        }

        public static void Excluir(int id)
        {
            VerificarLista();
            Subconta s = listaSubcontas.FirstOrDefault(f => f.id == id);
            if (s != null)
                listaSubcontas.Remove(s);
        }

        public static IList<Subconta> ObterPorParametros(string numeroSubconta, string numeroProcesso, string titular)
        {
            // todo
            return listaSubcontas;
        }
    }
}