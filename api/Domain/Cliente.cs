using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCurso.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
