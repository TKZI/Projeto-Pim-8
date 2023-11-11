using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Produto
    {

        public int Id { get; set; }

        public string descricao { get; set; }

        public decimal preco { get; set; }

        public string imagem { get; set; }

        public string status { get; set; }

        public int vendedorId { get; set; }

        public string categoria { get; set; }

    }
}