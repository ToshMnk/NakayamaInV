using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    public class PedidoModel
    {
        public int ID_Pedido { get; set; } 
        public int ID_Desing { get; set; }  
        public int CantidadPrendas { get; set; }
        public DateTime FechaPedido { get; set; } 
        public DateTime? FechaEntrega { get; set; }
        public string Estado { get; set; }
        public string Codigo { get; set; }  // Nueva propiedad para el código de diseño

    }

}
