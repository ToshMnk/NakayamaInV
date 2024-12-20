using NakayamaPJ.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Repository
{
    public class PedidoRepository : RepositoryBase
    {
        public List<PedidoModel> ObtenerPedidos()
        {
            var pedidos = new List<PedidoModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                            SELECT p.ID_Pedido, 
                                   p.ID_Desing, 
                                   d.codigo,  -- Obtener el campo codigo de la tabla Desing
                                   p.CantidadPrendas, 
                                   p.FechaPedido, 
                                   p.FechaEntrega, 
                                   p.Estado
                            FROM Pedido p
                            JOIN Desing d ON p.ID_Desing = d.ID_Desing";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedidos.Add(new PedidoModel
                            {
                                ID_Pedido = reader.GetInt32(0),
                                ID_Desing = reader.GetInt32(1),
                                Codigo = reader.GetString(2),  // Leer el campo codigo
                                CantidadPrendas = reader.GetInt32(3),
                                FechaPedido = reader.GetDateTime(4),
                                FechaEntrega = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                Estado = reader.GetString(6)
                            });
                        }
                    }
                }

            }
            return pedidos;
        }

        public void AgregarPedido(PedidoModel pedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "INSERT INTO Pedido (ID_Desing, CantidadPrendas, FechaEntrega) VALUES (@ID_Desing, @CantidadPrendas, @FechaEntrega)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Desing", pedido.ID_Desing);
                    command.Parameters.AddWithValue("@CantidadPrendas", pedido.CantidadPrendas);
                    command.Parameters.AddWithValue("@FechaEntrega", (object)pedido.FechaEntrega ?? DBNull.Value); // Permite FechaEntrega nula
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPedido(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Pedido WHERE ID_Pedido = @ID_Pedido";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Pedido", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarPedido(PedidoModel pedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
               
                var query = "UPDATE Pedido SET ID_Desing = @ID_Desing, CantidadPrendas = @CantidadPrendas, FechaEntrega = @FechaEntrega, Estado = @Estado WHERE ID_Pedido = @ID_Pedido";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Pedido", pedido.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Desing", pedido.ID_Desing);
                    command.Parameters.AddWithValue("@CantidadPrendas", pedido.CantidadPrendas);
                    command.Parameters.AddWithValue("@FechaEntrega", (object)pedido.FechaEntrega ?? DBNull.Value); // Permite FechaEntrega nula
                    command.Parameters.AddWithValue("@Estado", pedido.Estado);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<PedidoModel> ObtenerDesings()
        {
            var pedidos = new List<PedidoModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"SELECT ID_Desing FROM Desing";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedidos.Add(new PedidoModel
                            {
                                ID_Desing = reader.GetInt32(0)
                            });
                        }
                    }
                }
            }
            return pedidos;
        }
    }


}
