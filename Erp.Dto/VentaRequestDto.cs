using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Dto
{
    public class VentaRequestDto
    {
        public int IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public IList<VentaDetalleRequestDto> VentaDetalleList { get; set;}
    }

    public class VentaDetalleRequestDto
    {
        public int IdProducto { get; set;  }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
