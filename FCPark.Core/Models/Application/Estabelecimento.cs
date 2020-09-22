using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FCPark.Core
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public string CNPJ { get; set; }        
        public string Endereco { get; set; }        
        public string Telefone { get; set; }        
        public int QtdVagasMotos { get; set; }        
        public int QtdVagasCarros { get; set; }
    }
}
