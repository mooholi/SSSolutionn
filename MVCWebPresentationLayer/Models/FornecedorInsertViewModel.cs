using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebPresentationLayer.Models
{
    public class FornecedorInsertViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage ="O nome deve ser informado")]
        [StringLength(maximumLength:100 , MinimumLength =3,ErrorMessage ="O nome deve conter entre 5 e 40 caracteres")]
        public int ID { get; set; }

        public string Fornecedor { get; set; }

        public string Email { get; set; }

        public string CNPJ { get; set; }

        public Endereco Endereco { get; set; } 
    }
}