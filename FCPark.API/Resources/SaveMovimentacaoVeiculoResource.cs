﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCPark.API.Resources
{
    public class SaveMovimentacaoVeiculoResource
    {
        public int Id { get; set; }

        public int VeiculoId { get; set; }

        public int EstabelecimentoId { get; set; }
        public int ClienteId { get; set; }
         
        public DateTime? DataSaida { get; set; }
    }
}
