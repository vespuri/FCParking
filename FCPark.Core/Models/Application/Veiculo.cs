using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FCPark.Core
{
    public class Veiculo
    {
        public int Id { get; set; }
        /// <summary>
        /// A Marca do Veículo
        /// </summary>
        /// <example>Men's basketball shoes</example>
        public string Marca { get; set; }        
        public string Modelo { get; set; }        
        public string Cor { get; set; }        
        public string Placa { get; set; }        
        public string Tipo { get; set; }
        
    }

    public class MarcaFipe
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }

}
