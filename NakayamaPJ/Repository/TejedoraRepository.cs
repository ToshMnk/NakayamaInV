using NakayamaPJ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NakayamaPJ.Repository
{
    public class TejedoraRepository : RepositoryBase
    {
        public List<TejedoraModel> ObtenerTejedoras()
        {
            var tejedoras = new List<TejedoraModel>();
            using (var connection = GetConnection())
            {
                connection.Open();
                // Ajustamos el nombre de las columnas según la nueva estructura
                var query = "SELECT ID_Tejedora, Dni, Nombre, Apellido, Telefono FROM Tejedora";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tejedoras.Add(new TejedoraModel
                            {
                                ID_Tejedora = reader.GetInt32(0),  // ID_Tejedora
                                DNI = reader.GetString(1), // Dni
                                Nombre = reader.GetString(2),
                                Apellido = reader.GetString(3),
                                Telefono = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return tejedoras;
        }

        public void AgregarTejedora(TejedoraModel tejedora)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // Ajustamos la consulta de inserción para eliminar el campo no existente "CorreoElectronico"
                var query = "INSERT INTO Tejedora (Dni, Nombre, Apellido, Telefono) VALUES (@Dni, @Nombre, @Apellido, @Telefono)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Dni", tejedora.DNI);
                    command.Parameters.AddWithValue("@Nombre", tejedora.Nombre);
                    command.Parameters.AddWithValue("@Apellido", tejedora.Apellido);
                    command.Parameters.AddWithValue("@Telefono", tejedora.Telefono);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarTejedora(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // Ajustamos el nombre del campo de ID para que sea "ID_Tejedora"
                var query = "DELETE FROM Tejedora WHERE ID_Tejedora = @ID_Tejedora";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Tejedora", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarTejedora(TejedoraModel tejedora)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // Ajustamos el nombre del campo de ID y el resto de los campos para que coincidan con la nueva estructura
                var query = "UPDATE Tejedora SET Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono WHERE ID_Tejedora = @ID_Tejedora";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Tejedora", tejedora.ID_Tejedora);
                    command.Parameters.AddWithValue("@Dni", tejedora.DNI);
                    command.Parameters.AddWithValue("@Nombre", tejedora.Nombre);
                    command.Parameters.AddWithValue("@Apellido", tejedora.Apellido);
                    command.Parameters.AddWithValue("@Telefono", tejedora.Telefono);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
