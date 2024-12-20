using System;
using System.Collections.Generic;

namespace NakayamaPJ.Model
{
    public class MateriaPrima
    {
        public int Id { get; set; } // Mapea ID_MateriaPrima
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public decimal StockActual { get; set; }
    }

    public class Produccion
    {
        public int Id { get; set; } // Mapea ID_Produccion
        public int PedidoId { get; set; } // Mapea ID_Pedido
        public int TejedoraId { get; set; } // Mapea ID_Tejedora
        public int CantidadPrendas { get; set; }
        public decimal CantidadLana { get; set; }
        public decimal CantidadMerma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } // Puede ser nulo
        public bool EsMuestra { get; set; } // Mapea EsMuestra
    }

    public class Pago
    {
        public int Id { get; set; } // Mapea ID_Pago
        public int TejedoraId { get; set; } // Mapea ID_Tejedora
        public int ProduccionId { get; set; } // Mapea ID_Produccion
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
    }

    public class ProduccionSemanal
    {
        public int Año { get; set; }
        public int Semana { get; set; }
        public int PrendasTerminadas { get; set; }
    }


    public class PagosPendientes
    {
        public string NombreTejedora { get; set; }
        public string ApellidoTejedora { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
