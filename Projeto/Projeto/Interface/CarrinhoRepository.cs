using Projeto.DB;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto.Interface
{
    public class CarrinhoRepository : IRepository<Carrinho>
    {
        private string connectionString; // string conecction com o banco

        public CarrinhoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Carrinho carrinho)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Carrinho (id, dataPedido, valorTotal, clienteId, statusPedido) " +
                               "VALUES (@id, @dataPedido, @valorTotal, @clienteId, @statusPedido)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", carrinho.Id);
                command.Parameters.AddWithValue("@dataPedido", carrinho.dataPedido);
                command.Parameters.AddWithValue("@valorTotal", carrinho.valorTotal);
                command.Parameters.AddWithValue("@clienteId", carrinho.clienteId);
                command.Parameters.AddWithValue("@statusPedido", carrinho.statusPedido);

                command.ExecuteNonQuery();
            }
        }

        public void Atualizar(Carrinho carrinho)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Carrinho " +
                               "SET dataPedido = @dataPedido, valorTotal = @valorTotal, clienteId = @clienteId , statusPedido = @statusPedido " +
                               "WHERE id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", carrinho.Id);
                command.Parameters.AddWithValue("@dataPedido", carrinho.dataPedido);
                command.Parameters.AddWithValue("@valorTotal", carrinho.valorTotal);
                command.Parameters.AddWithValue("@clienteId", carrinho.clienteId);
                command.Parameters.AddWithValue("@statusPedido", carrinho.statusPedido);

                command.ExecuteNonQuery();
            }
        }

        public void Excluir(Carrinho carrinho)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Carrinho WHERE id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", carrinho.Id);

                command.ExecuteNonQuery();
            }
        }

        public Carrinho ObterPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, dataPedido, valorTotal, clienteId, statusPedido FROM Carrinho WHERE id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Carrinho carrinho = new Carrinho
                    {
                        Id = reader.GetInt32(0),
                        dataPedido = reader.GetDateTime(1),
                        valorTotal = reader.GetDecimal(2),
                        clienteId = reader.GetInt32(3),
                        statusPedido = reader.GetInt32(4)
                    };

                    return carrinho;
                }

                return null; // Retorna nulo se o carrinho não for encontrado
            }
        }

        public List<Carrinho> ObterTodos()
        {
            List<Carrinho> carrinhos = new List<Carrinho>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, dataPedido, valorTotal, clienteId, statusPedido FROM Carrinho";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Carrinho carrinho = new Carrinho
                    {
                        Id = reader.GetInt32(0),
                        dataPedido = reader.GetDateTime(1),
                        valorTotal = reader.GetDecimal(2),
                        clienteId = reader.GetInt32(3),
                        statusPedido = reader.GetInt32(3)
                    };

                    carrinhos.Add(carrinho);
                }
            }

            return carrinhos;
        }
    }
}