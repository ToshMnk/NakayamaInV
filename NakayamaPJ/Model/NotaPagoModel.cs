using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    public class NotaPagoModel
    {
        public int ID_Pago { get; set; }
        public int ID_Tejedora { get; set; }
        public int ID_Produccion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
    }

}
