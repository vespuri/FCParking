using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCPark.API.Resources
{
    public class VeiculoResource
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
    }
}
