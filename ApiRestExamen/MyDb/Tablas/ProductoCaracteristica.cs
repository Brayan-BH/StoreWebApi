using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestExamen.MyDb.Tablas
{
    [Table("ProductoCaracteristica")]
    public class ProductoCaracteristica
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int producto_id { get; set; }

    }
}
