using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    public class ProduccionModel
    {
        public int ID_Produccion { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Tejedora { get; set; }
        public int ID_Desing { get; set; }
        public int ID_Lana { get; set; }
        public int CantidadPrendas { get; set; }
        public decimal CantidadLana { get; set; }
        public decimal CantidadMerma { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool EsMuestra { get; set; }
        public string NombreTejedora { get; set; }

    }
}
