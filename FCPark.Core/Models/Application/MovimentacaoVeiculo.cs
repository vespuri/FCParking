using System;
using System.Collections.Generic;
using System.Text;

namespace FCPark.Core
{
    public class MovimentacaoVeiculo
    {
        public int Id { get; set; }

        public int VeiculoId { get; set; }

        public int EstabelecimentoId { get; set; }

        public int ClienteId { get; set; }

        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}
