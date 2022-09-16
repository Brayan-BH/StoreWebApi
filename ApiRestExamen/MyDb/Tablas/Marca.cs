using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestExamen.MyDb.Tablas
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string logo_url { get; set; }

    }
}
