using System;
using System.Collections.Generic;
using System.Text;

namespace FCPark.Core
{
    public class TotalsReport
    {
        public DateTime Dia { get; set; }
        public int Hora { get; set; }
        public int Total { get; set; }
        public string Movimento { get; set; }

        public int TotalSaida {get;set;}
        public int TotalEntrada { get; set; }
    }
}
