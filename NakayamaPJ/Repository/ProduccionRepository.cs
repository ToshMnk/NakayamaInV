using NakayamaPJ.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NakayamaPJ.Repository
{
    public class ProduccionRepository : RepositoryBase
    {
        public List<ProduccionModel> ObtenerProducciones()
        {
            var producciones = new List<ProduccionModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                            SELECT p.ID_Produccion,
                                   p.ID_Pedido,
                                   p.ID_Tejedora,
                                   p.CantidadPrendas,
                                   p.CantidadLana,
                                   p.CantidadMerma,
                                   p.FechaInicio,
                                   p.FechaFin,
                                   p.EsMuestra
                            FROM Produccion p";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producciones.Add(new ProduccionModel
                            {
                                ID_Produccion = reader.GetInt32(0),
                                ID_Pedido = reader.GetInt32(1),
                                ID_Tejedora = reader.GetInt32(2),
                                CantidadPrendas = reader.GetInt32(3),
                                CantidadLana = reader.GetDecimal(4),
                                CantidadMerma = reader.GetDecimal(5),
                                FechaInicio = reader.GetDateTime(6),
                                FechaFin = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                                EsMuestra = reader.GetBoolean(8)
                            });
                        }
                    }
                }
            }
            return producciones;
        }

        public void AgregarProduccion(ProduccionModel produccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                            INSERT INTO Produccion (ID_Pedido, ID_Tejedora, CantidadPrendas, CantidadLana, CantidadMerma, FechaFin, EsMuestra) 
                            VALUES (@ID_Pedido, @ID_Tejedora, @CantidadPrendas, @CantidadLana, @CantidadMerma, @FechaFin, @EsMuestra)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Pedido", produccion.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Tejedora", produccion.ID_Tejedora);
                    command.Parameters.AddWithValue("@CantidadPrendas", produccion.CantidadPrendas);
                    command.Parameters.AddWithValue("@CantidadLana", produccion.CantidadLana);
                    command.Parameters.AddWithValue("@CantidadMerma", produccion.CantidadMerma);
                    command.Parameters.AddWithValue("@FechaFin", (object)produccion.FechaFin ?? DBNull.Value); // FechaFin puede ser nula
                    command.Parameters.AddWithValue("@EsMuestra", produccion.EsMuestra);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProduccion(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Produccion WHERE ID_Produccion = @ID_Produccion";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Produccion", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarProduccion(ProduccionModel produccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                            UPDATE Produccion 
                            SET ID_Pedido = @ID_Pedido, 
                                ID_Tejedora = @ID_Tejedora, 
                                CantidadPrendas = @CantidadPrendas, 
                                CantidadLana = @CantidadLana, 
                                CantidadMerma = @CantidadMerma, 
                                FechaFin = @FechaFin, 
                                EsMuestra = @EsMuestra
                            WHERE ID_Produccion = @ID_Produccion";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Produccion", produccion.ID_Produccion);
                    command.Parameters.AddWithValue("@ID_Pedido", produccion.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Tejedora", produccion.ID_Tejedora);
                    command.Parameters.AddWithValue("@CantidadPrendas", produccion.CantidadPrendas);
                    command.Parameters.AddWithValue("@CantidadLana", produccion.CantidadLana);
                    command.Parameters.AddWithValue("@CantidadMerma", produccion.CantidadMerma);
                    command.Parameters.AddWithValue("@FechaFin", (object)produccion.FechaFin ?? DBNull.Value); // Permite FechaFin nula
                    command.Parameters.AddWithValue("@EsMuestra", produccion.EsMuestra);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<ProduccionModel> BuscarProducciones(string searchText)
        {
            var produccionesFiltradas = new List<ProduccionModel>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
        SELECT p.ID_Produccion,
               p.ID_Pedido,
               p.ID_Tejedora,
               p.CantidadPrendas,
               p.CantidadLana,
               p.CantidadMerma,
               p.FechaInicio,
               p.FechaFin,
               p.EsMuestra,
               t.Nombre AS NombreTejedora
        FROM Produccion p
        INNER JOIN Tejedora t ON p.ID_Tejedora = t.ID_Tejedora
        WHERE p.ID_Produccion LIKE @SearchText OR
              p.ID_Pedido LIKE @SearchText OR
              t.Nombre LIKE @SearchText";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produccionesFiltradas.Add(new ProduccionModel
                            {
                                ID_Produccion = reader.GetInt32(0),
                                ID_Pedido = reader.GetInt32(1),
                                ID_Tejedora = reader.GetInt32(2),
                                CantidadPrendas = reader.GetInt32(3),
                                CantidadLana = reader.GetDecimal(4),
                                CantidadMerma = reader.GetDecimal(5),
                                FechaInicio = reader.GetDateTime(6),
                                FechaFin = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                                EsMuestra = reader.GetBoolean(8),
                                NombreTejedora = reader.GetString(9)
                            });
                        }
                    }
                }
            }

            return produccionesFiltradas;
        }

        public List<TejedoraModel> ObtenerTejedoras()
        {
            var tejedoras = new List<TejedoraModel>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT ID_Tejedora, Nombre FROM Tejedora";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tejedoras.Add(new TejedoraModel
                        {
                            ID_Tejedora = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                }
            }
            return tejedoras;
        }

        public List<PedidoModel> ObtenerPedidos()
        {
            var pedidos = new List<PedidoModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"SELECT ID_Pedido FROM Pedidos";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedidos.Add(new PedidoModel
                            {
                                ID_Pedido = reader.GetInt32(0)
                            });
                        }
                    }
                }
            }
            return pedidos;
        }

        public List<PedidoModel> ObtenerPedidosDisponibles()
        {
            var pedidos = new List<PedidoModel>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT ID_Pedido, Estado FROM Pedido WHERE Estado = 'En produccion'";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pedidos.Add(new PedidoModel
                        {
                            ID_Pedido = reader.GetInt32(0),
                            Estado = reader.GetString(1)
                        });
                    }
                }
            }
            return pedidos;
        }

        public List<ProduccionModel> ObtenerProduccionesConTejedoras()
        {
            var producciones = new List<ProduccionModel>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
            SELECT 
                p.ID_Pedido, 
                t.Nombre AS NombreTejedora, 
                p.ID_Tejedora, 
                p.CantidadPrendas, 
                p.FechaInicio
            FROM 
                Produccion p
            INNER JOIN 
                Tejedora t ON p.ID_Tejedora = t.ID_Tejedora";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        producciones.Add(new ProduccionModel
                        {
                            ID_Pedido = reader.GetInt32(0),
                            NombreTejedora = reader.GetString(1), // Asegúrate de tener esta propiedad en el modelo
                            ID_Tejedora = reader.GetInt32(2),
                            CantidadPrendas = reader.GetInt32(3),
                            FechaInicio = reader.GetDateTime(4)
                        });
                    }
                }
            }

            return producciones;
        }


    }
}
