using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto.DB
{
    public class Pim8MVCContext : DbContext
    {
        public Pim8MVCContext()
            : base("Pim") // Substitua pelo nome real da sua string de conexão
        {
            
        }

        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Produto> produtos { get; set; }

        

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}