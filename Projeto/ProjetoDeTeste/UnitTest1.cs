using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.Interface;
using Projeto.Models;
using System;
using System.Collections.Generic;

namespace ProjetoDeTeste
{
    [TestClass]
    public class UnitTest1
    {

        private string connectionString = "Data Source=DESKTOP-FHHIUOQ;Initial Catalog=Pim;Integrated Security=True;MultipleActiveResultSets=True;";

        //carrinho de teste para inclusão no banco
        Carrinho carrinhoNovo = new Carrinho()
        { Id = 2,
            dataPedido = new DateTime(2022, 11, 11, 11, 36, 42),
            valorTotal = 199.00M,
            clienteId = 2,
            statusPedido = 3

        };
       

        [TestMethod]
        public void TestAdicionar()
        {
            // Criar um objeto Carrinho de teste
            Carrinho carrinho = new Carrinho
            {
                Id = 6,
                dataPedido = new DateTime(2022, 11, 11, 11, 36, 42),
                valorTotal = 199.00M,
                clienteId = 1,
               statusPedido = 3
            };

            // Criar uma instância do CarrinhoRepository
            CarrinhoRepository carrinhoRepository = new CarrinhoRepository(connectionString);

            // opcional, para alterar o carrinho criado no próprio método
            carrinhoRepository.Adicionar(carrinho);

            // Recupera o Carrinho do banco de dados usando o método ObterPorId
            Carrinho carrinhoInserido = carrinhoRepository.ObterPorId(carrinho.Id);

            // Verifique se o Carrinho foi adicionado corretamente
            Assert.IsNotNull(carrinhoInserido);
            Assert.AreEqual(carrinho.Id, carrinhoInserido.Id);
        }

        [TestMethod]
        public void TestAtualizar()
        {
            
            CarrinhoRepository carrinhoRepository = new CarrinhoRepository(connectionString);


            //precisa alterar toda vez que roda o teste
            carrinhoNovo.Id = 2;
            carrinhoNovo.dataPedido = new DateTime(2023, 11, 12, 21, 46, 43);
            carrinhoNovo.valorTotal = 134.00M;
            carrinhoNovo.clienteId = 2;
            carrinhoNovo.statusPedido = 4;

            
            carrinhoRepository.Atualizar(carrinhoNovo);

           
            Carrinho carrinhoAtualizado = carrinhoRepository.ObterPorId(carrinhoNovo.Id);

            
            Assert.IsNotNull(carrinhoAtualizado);
            Assert.AreEqual(carrinhoNovo.Id, carrinhoAtualizado.Id);
            Assert.AreEqual(carrinhoNovo.dataPedido, carrinhoAtualizado.dataPedido);
            Assert.AreEqual(carrinhoNovo.valorTotal, carrinhoAtualizado.valorTotal);
            Assert.AreEqual(carrinhoNovo.statusPedido, carrinhoAtualizado.statusPedido);
        }

        [TestMethod]
        public void TestExcluir()
        {
            // Criar um objeto Carrinho de teste
            Carrinho carrinho = new Carrinho
            {
                Id = 6,
                
            };

           
            CarrinhoRepository carrinhoRepository = new CarrinhoRepository(connectionString);

                                    
            carrinhoRepository.Excluir(carrinho);

            // Tenta recuperar o Carrinho excluído do banco de dados usando o método ObterPorId
            Carrinho carrinhoExcluido = carrinhoRepository.ObterPorId(carrinho.Id);

            // Verifica se o Carrinho foi excluído corretamente
            Assert.IsNull(carrinhoExcluido);
        }

        [TestMethod]
        public void TestObterPorId()
        {
             CarrinhoRepository carrinhoRepository = new CarrinhoRepository(connectionString);

            
            // Recupera o Carrinho do banco de dados usando o método ObterPorId
            Carrinho carrinhoObtido = carrinhoRepository.ObterPorId(carrinhoNovo.Id);

            // Verifica se o Carrinho foi recuperado corretamente
            Assert.IsNotNull(carrinhoObtido);
            Assert.AreEqual(carrinhoNovo.Id, carrinhoObtido.Id);
        }

        [TestMethod]
        public void TestObterTodos()
        {
            
            CarrinhoRepository carrinhoRepository = new CarrinhoRepository(connectionString);

            // Executa o método ObterTodos
            List<Carrinho> carrinhos = carrinhoRepository.ObterTodos();

            // Verifica se a lista de Carrinhos não é nula
            Assert.IsNotNull(carrinhos);
        }
    }
}
