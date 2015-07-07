using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutJS_WebApi2.Models
{
    public class Subconta
    {
        public int id { get; set; }
        public string numeroSubconta { get; set; }
        public string numeroProcesso { get; set; }
        public string titular { get; set; }
        public DateTime dataAbertura { get; set; }
        public Movimentacao[] movimentacoes { get; set; }
    }
}