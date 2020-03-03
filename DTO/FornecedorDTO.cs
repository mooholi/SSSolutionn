using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FornecedorDTO
    {
        public int ID { get; set; }
        public string Fornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
    }
}
