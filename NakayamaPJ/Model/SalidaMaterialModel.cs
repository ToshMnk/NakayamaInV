using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    public class SalidaMaterialModel
    {
        public int ID_Salida_Material { get; set; }
        public int ID_MateriaPrima { get; set; }
        public int ID_Produccion { get; set; }
        public decimal CantidadLana { get; set; }
        public DateTime FechaRegistro { get; set; }  // Este campo se llenará automáticamente
        public string TipoMovimiento { get; set; }   // 'Entrada' o 'Salida'
    }
}
