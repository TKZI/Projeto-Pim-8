using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Unity.Injection;

namespace Projeto.Models
{
    public class Carrinho {
        

        

        
        public int Id { get; set; }

        public DateTime dataPedido { get; set; }

        public decimal valorTotal { get; set; }

        public int statusPedido { get; set; }

        
        public int clienteId { get; set; }
        
        








    }
}
