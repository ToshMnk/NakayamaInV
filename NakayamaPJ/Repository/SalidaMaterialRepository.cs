using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakayamaPJ.Model;
using NakayamaPJ.Repository;

namespace NakayamaPJ.Repository
{
    public class SalidaMaterialRepository : RepositoryBase
    {
        public List<SalidaMaterialModel> ObtenerSalidasMaterial()
        {
            var salidas = new List<SalidaMaterialModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                    SELECT ID_Salida_Material, ID_MateriaPrima, ID_Produccion, CantidadLana, FechaRegistro, TipoMovimiento 
                    FROM Salida_Material";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salidas.Add(new SalidaMaterialModel
                            {
                                ID_Salida_Material = reader.GetInt32(0),
                                ID_MateriaPrima = reader.GetInt32(1),
                                ID_Produccion = reader.GetInt32(2),
                                CantidadLana = reader.GetDecimal(3),
                                FechaRegistro = reader.GetDateTime(4),
                                TipoMovimiento = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return salidas;
        }

        public void AgregarSalidaMaterial(SalidaMaterialModel salida)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // La columna FechaRegistro se autocompleta con GETDATE(), por lo tanto no se envía
                var query = @"
                    INSERT INTO Salida_Material (ID_MateriaPrima, ID_Produccion, CantidadLana, TipoMovimiento) 
                    VALUES (@ID_MateriaPrima, @ID_Produccion, @CantidadLana, @TipoMovimiento)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_MateriaPrima", salida.ID_MateriaPrima);
                    command.Parameters.AddWithValue("@ID_Produccion", salida.ID_Produccion);
                    command.Parameters.AddWithValue("@CantidadLana", salida.CantidadLana);
                    command.Parameters.AddWithValue("@TipoMovimiento", salida.TipoMovimiento);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarSalidaMaterial(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Salida_Material WHERE ID_Salida_Material = @ID_Salida_Material";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Salida_Material", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarSalidaMaterial(SalidaMaterialModel salida)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
                    UPDATE Salida_Material 
                    SET ID_MateriaPrima = @ID_MateriaPrima, 
                        ID_Produccion = @ID_Produccion, 
                        CantidadLana = @CantidadLana, 
                        TipoMovimiento = @TipoMovimiento 
                    WHERE ID_Salida_Material = @ID_Salida_Material";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Salida_Material", salida.ID_Salida_Material);
                    command.Parameters.AddWithValue("@ID_MateriaPrima", salida.ID_MateriaPrima);
                    command.Parameters.AddWithValue("@ID_Produccion", salida.ID_Produccion);
                    command.Parameters.AddWithValue("@CantidadLana", salida.CantidadLana);
                    command.Parameters.AddWithValue("@TipoMovimiento", salida.TipoMovimiento);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
