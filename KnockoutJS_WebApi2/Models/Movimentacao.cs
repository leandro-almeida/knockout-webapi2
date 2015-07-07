using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnockoutJS_WebApi2.Models
{
    public class Movimentacao
    {
        public int numeroSequencial { get; set; }
        public string numeroSubconta { get; set; }
        public int tipo { get; set; }
        public DateTime data { get; set; }
        public decimal valor { get; set; }
    }
}
