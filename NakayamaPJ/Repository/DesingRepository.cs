using NakayamaPJ.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Repository
{
    public class DesingRepository : RepositoryBase
    {
        // Obtener todos los diseños
        public List<DesingModel> ObtenerDiseños()
        {
            var disenios = new List<DesingModel>();
            using (var connection = GetConnection())
            {
                connection.Open();

                // Consulta para obtener los diseños
                var query = "SELECT ID_Desing, Tamano, Precio, Codigo, Peso, Bordado, EsMuestra FROM Desing";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            disenios.Add(new DesingModel
                            {
                                ID_Desing = reader.GetInt32(0), // Primer columna: ID_Desing
                                Tamano = reader.GetString(1),   // Segunda columna: Tamano
                                Precio = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),  // Tercera columna: Precio
                                Codigo = reader.GetString(3),   // Cuarta columna: Codigo
                                Peso = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4),    // Quinta columna: Peso
                                Bordado = reader.GetBoolean(5), // Sexta columna: Bordado
                                EsMuestra = reader.GetBoolean(6) // Séptima columna: EsMuestra
                            });
                        }
                    }
                }
            }
            return disenios;
        }


        // Agregar un diseño
        public void AgregarDesing(DesingModel diseño)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Iniciar una transacción para asegurar que ambas tablas se actualicen correctamente
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Primero insertamos el diseño en la tabla 'Desing'
                        var queryDesing = "INSERT INTO Desing (Tamano, Precio, Codigo, Peso, Bordado, EsMuestra) " +
                                          "VALUES (@Tamano, @Precio, @Codigo, @Peso, @Bordado, @EsMuestra); " +
                                          "SELECT SCOPE_IDENTITY();"; // Obtener el ID del diseño recién insertado

                        using (var command = new SqlCommand(queryDesing, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Tamano", diseño.Tamano);
                            command.Parameters.AddWithValue("@Precio", diseño.Precio.HasValue ? diseño.Precio.Value : (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Codigo", diseño.Codigo);
                            command.Parameters.AddWithValue("@Peso", diseño.Peso.HasValue ? diseño.Peso.Value : (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Bordado", diseño.Bordado);
                            command.Parameters.AddWithValue("@EsMuestra", diseño.EsMuestra);

                            // Ejecutar el comando y obtener el ID del diseño insertado
                            var idDesing = Convert.ToInt32(command.ExecuteScalar());

                            // Ahora insertamos los materiales asociados al diseño en la tabla 'Desing_MateriaPrima'
                            foreach (var material in diseño.MateriasPrimas)  // Suponiendo que tienes una lista de materiales en el modelo
                            {
                                var queryMateriaPrima = "INSERT INTO Desing_MateriaPrima (ID_Desing, ID_MateriaPrima, CantidadMaterial) " +
                                                        "VALUES (@ID_Desing, @ID_MateriaPrima, @CantidadMaterial)";
                                using (var commandMateriaPrima = new SqlCommand(queryMateriaPrima, connection, transaction))
                                {
                                    commandMateriaPrima.Parameters.AddWithValue("@ID_Desing", idDesing);  // Usamos el ID del diseño insertado
                                    commandMateriaPrima.Parameters.AddWithValue("@ID_MateriaPrima", material.IDMateriaPrima);  // ID de la materia prima
                                    commandMateriaPrima.Parameters.AddWithValue("@CantidadMaterial", material.CantidadMaterial);  // Cantidad de material

                                    commandMateriaPrima.ExecuteNonQuery();
                                }
                            }
                        }

                        // Si todo va bien, confirmamos la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre algún error, hacemos un rollback para no dejar los datos inconsistentes
                        transaction.Rollback();
                        throw new Exception("Error al agregar diseño y sus materiales: " + ex.Message);
                    }
                }
            }
        }


        // Eliminar un diseño
        public void EliminarDesing(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Desing WHERE ID_Desing = @ID_Desing";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Desing", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Actualizar un diseño
        public void ActualizarDesing(DesingModel diseño)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "UPDATE Desing SET Tamano = @Tamano, Precio = @Precio, " +
                            "Codigo = @Codigo, Peso = @Peso, Bordado = @Bordado, EsMuestra = @EsMuestra WHERE ID_Desing = @ID_Desing";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Desing", diseño.ID_Desing);
                    command.Parameters.AddWithValue("@Tamano", diseño.Tamano);
                    command.Parameters.AddWithValue("@Precio", diseño.Precio.HasValue ? diseño.Precio.Value : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Codigo", diseño.Codigo);
                    command.Parameters.AddWithValue("@Peso", diseño.Peso.HasValue ? diseño.Peso.Value : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Bordado", diseño.Bordado);
                    command.Parameters.AddWithValue("@EsMuestra", diseño.EsMuestra);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
