using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Cliente
    {
        
        public int clienteId { get; set; }

        public string Nome { get; set; }

        public long CPF { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Endereco { get; set; }

        
       




    }
}