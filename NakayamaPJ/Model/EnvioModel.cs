using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    class EnvioModel
    {
        public int ID_Envio { get; set; }
        public int ID_Pedido { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
    }
}
