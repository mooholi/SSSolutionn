using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebPresentationLayer.Models
{
    public class ClienteInsertViewModel
    {
        public string Nome{ get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento{ get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }

    }
}