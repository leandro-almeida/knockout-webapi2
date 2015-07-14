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
        public int codigoMovimentacao { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public decimal valor { get; set; }
        public string usuario { get; set; }
        public string complemento { get; set; }
    }
}
