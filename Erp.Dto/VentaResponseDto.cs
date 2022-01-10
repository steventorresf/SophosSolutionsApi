using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Dto
{
    public class VentaResponseDto
    {
        public int NoVenta { get; set; }
        public string NombreCliente { get; set; }
        public string FechaVenta { get; set; }
        public IList<VentaDetalleResponseDto> VentaDetalleList { get; set; }
    }

    public class VentaDetalleResponseDto
    {
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
