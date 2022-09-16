using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestExamen.MyDb.Tablas
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; } 
        public int categoria_padre { get; set; }

    }
}
