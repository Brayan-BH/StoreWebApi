using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestExamen.MyDb.Tablas
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int id { get; set; } 
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo_barras {get; set; }
        public decimal precioVenta { get; set; }
        public int categoria_id { get; set; }
        public int marca_id { get; set; }
    }
}
