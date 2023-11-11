using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Vendedor
    {

        public int vendedorId { get; set; }

        public string razaoSocial { get; set; }

        public string nomeFantasia { get; set; }

        public string cnpj { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public decimal comissao { get; set; }

        public string endereco { get; set; }

        

    }
}