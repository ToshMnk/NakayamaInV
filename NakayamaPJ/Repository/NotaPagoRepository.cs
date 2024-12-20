using NakayamaPJ.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NakayamaPJ.Repository
{
    public class NotaPagoRepository : RepositoryBase
    {
        public List<NotaPagoModel> ObtenerNotaPagos()
        {
            var notaPagos = new List<NotaPagoModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                            SELECT np.ID_Pago, 
                                   np.ID_Tejedora, 
                                   np.ID_Produccion, 
                                   np.Monto, 
                                   np.FechaPago, 
                                   np.MetodoPago
                            FROM Pagos np";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notaPagos.Add(new NotaPagoModel
                            {
                                ID_Pago = reader.GetInt32(0),
                                ID_Tejedora = reader.GetInt32(1),
                                ID_Produccion = reader.GetInt32(2),
                                Monto = reader.GetDecimal(3),
                                FechaPago = reader.GetDateTime(4),
                                MetodoPago = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return notaPagos;
        }

        public void AgregarNotaPago(NotaPagoModel notaPago)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "INSERT INTO Pagos (ID_Tejedora, ID_Produccion, Monto, MetodoPago) VALUES (@ID_Tejedora, @ID_Produccion, @Monto, @MetodoPago)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Tejedora", notaPago.ID_Tejedora);
                    command.Parameters.AddWithValue("@ID_Produccion", notaPago.ID_Produccion);
                    command.Parameters.AddWithValue("@Monto", notaPago.Monto);
                    command.Parameters.AddWithValue("@MetodoPago", notaPago.MetodoPago);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarNotaPago(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Pagos WHERE ID_Pago = @ID_Pago";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Pago", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarNotaPago(NotaPagoModel notaPago)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "UPDATE Pagos SET ID_Tejedora = @ID_Tejedora, ID_Produccion = @ID_Produccion, Monto = @Monto, FechaPago = @FechaPago, MetodoPago = @MetodoPago WHERE ID_Pago = @ID_Pago";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Pago", notaPago.ID_Pago);
                    command.Parameters.AddWithValue("@ID_Tejedora", notaPago.ID_Tejedora);
                    command.Parameters.AddWithValue("@ID_Produccion", notaPago.ID_Produccion);
                    command.Parameters.AddWithValue("@Monto", notaPago.Monto);
                    command.Parameters.AddWithValue("@FechaPago", notaPago.FechaPago);
                    command.Parameters.AddWithValue("@MetodoPago", notaPago.MetodoPago);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
