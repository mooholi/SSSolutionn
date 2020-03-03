using Common;
using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators
{
    internal class EnderecoValidator // TENTAR FAZER COM ABSTRACTVALIDATOR
    {
        public List<Error> Validate(Endereco endereco)
        {
            List<Error> errors = new List<Error>();
            if (string.IsNullOrWhiteSpace(endereco.Bairro))
            {
                errors.Add(new Error() { FieldName = "Bairro", Message = "Bairro deve ser informado." });
            }
            //FAZER DE TODOS OS CAMPOS
            return errors;
        }

    }
}
