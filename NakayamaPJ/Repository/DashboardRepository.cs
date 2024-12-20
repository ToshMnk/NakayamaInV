using NakayamaPJ.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NakayamaPJ.Repository
{
    public class DashboardRepository : RepositoryBase
    {
        // Método genérico para ejecutar consultas que devuelvan un valor único
        private T ExecuteScalar<T>(string query)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null && result != DBNull.Value
                        ? (T)Convert.ChangeType(result, typeof(T))
                        : default;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ejecutando consulta: {query}", ex);
            }
        }

        // Método genérico para ejecutar consultas que devuelvan múltiples filas
        private SqlDataReader ExecuteReader(string query)
        {
            try
            {
                var connection = GetConnection();
                var command = new SqlCommand(query, connection);
                connection.Open();
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ejecutando consulta: {query}", ex);
            }
        }

        // Consulta 1: Cantidad de prendas en producción
        public int ObtenerPrendasEnProduccion()
        {
            const string query = "SELECT COUNT(*) FROM Produccion WHERE FechaFin IS NULL;";
            return ExecuteScalar<int>(query);
        }

        // Consulta 2: Total de tejedoras activas
        public int ObtenerTejedorasActivas()
        {
            const string query = "SELECT COUNT(*) FROM Tejedora;";
            return ExecuteScalar<int>(query);
        }

        // Consulta 3: Producción semanal (Cantidad de prendas terminadas por semana)
        public List<ProduccionSemanal> ObtenerProduccionSemanal()
        {
            const string query = @"
            SELECT DATEPART(WEEK, FechaFin) AS Semana, SUM(CantidadPrendas) AS PrendasTerminadas
            FROM Produccion
            WHERE FechaFin IS NOT NULL
            GROUP BY DATEPART(WEEK, FechaFin)
            ORDER BY Semana;";

            var resultados = new List<ProduccionSemanal>();
            using (var reader = ExecuteReader(query))
            {
                while (reader.Read())
                {
                    resultados.Add(new ProduccionSemanal
                    {
                        Semana = reader.GetInt32(0),
                        PrendasTerminadas = reader.GetInt32(1)
                    });
                }
            }
            return resultados;
        }

        // Consulta 4: Pagos pendientes
        public List<PagosPendientes> ObtenerPagosPendientes()
        {
            const string query = @"
            SELECT T.Nombre, T.Apellido, P.Monto, P.FechaPago
            FROM Pagos P
            INNER JOIN Tejedora T ON T.ID_Tejedora = P.ID_Tejedora
            WHERE P.FechaPago > GETDATE();";

            var resultados = new List<PagosPendientes>();
            using (var reader = ExecuteReader(query))
            {
                while (reader.Read())
                {
                    resultados.Add(new PagosPendientes
                    {
                        NombreTejedora = reader.GetString(0),
                        ApellidoTejedora = reader.GetString(1),
                        Monto = reader.GetDecimal(2),
                        FechaPago = reader.GetDateTime(3)
                    });
                }
            }
            return resultados;
        }

        // Consulta 5: Stock de materia prima
        public decimal ObtenerStockMateriaPrima()
        {
            const string query = "SELECT SUM(StockActual) FROM MateriaPrima;";
            return ExecuteScalar<decimal>(query);
        }

        // Método asíncrono: Stock de materia prima
        public async Task<decimal> ObtenerStockMateriaPrimaAsync()
        {
            const string query = "SELECT SUM(StockActual) FROM MateriaPrima;";

            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        var result = await command.ExecuteScalarAsync();
                        return result != null && result != DBNull.Value
                            ? Convert.ToDecimal(result)
                            : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ejecutando consulta: {query}", ex);
            }
        }
    }
}
