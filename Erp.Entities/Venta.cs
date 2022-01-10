using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Entities
{
    [Table("Venta", Schema = "dbo")]
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime FechaVenta { get; set; }
    }
}
