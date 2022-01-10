using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Entities
{
    [Table("VentaDetalle", Schema = "dbo")]
    public class VentaDetalle
    {
        [Key]
        public int IdVentaDetalle { get; set; }

        [Required]
        public int IdVenta { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
