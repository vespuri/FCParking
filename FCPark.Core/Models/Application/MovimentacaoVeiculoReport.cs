using System;
using System.Collections.Generic;
using System.Text;

namespace FCPark.Core.Models.Application
{
    public class MovimentacaoVeiculoReport
    {
        string TipoMovimentacao { get; set; } //Entrada / Saída
        int TotalMovimentacao { get; set; }
        string HorarioMovimentacao { get; set; }
    }
}
