using ApiRestExamen.MyDb.Contexts;
using ApiRestExamen.MyDb.Tablas;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestExamen.Controllers
{
    [Controller]
    [Route("/api/v1/marcas")]
    public class MarcasController: ControllerBase
    {
        private readonly MyDbContext db;
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        public MarcasController (MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<Marca> marcas = db.Marcas.ToList();
            return Ok(marcas);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Marca marca)
        {
            db.Marcas.Add(marca);
            db.SaveChanges();
            return Ok(marca);

        }

        [HttpGet]
        [Route("{id}/productos")]

        public ActionResult ListarOne([FromRoute] int id)
        {

            var producto = db.Productos
                .Where(p => p.categoria_id == id);
            if (producto == null)
            {
                return NotFound(new { message = "No puedes listar los productos con el id: " + id });

            }

            List<Producto> productos = db.Productos.ToList();
            return Ok(producto);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Marca marcaDatos)
        {
            Marca? marca = db.Marcas
                .Where(p => p.id == id)
                .FirstOrDefault();
            if (marca == null)
            {
                return NotFound(new { message = "Marca no encontrado con el id: " + id });

            }
            marca.nombre = marcaDatos.nombre;
            marca.descripcion = marcaDatos.descripcion;
            marca.logo_url = marcaDatos.logo_url;

            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            Marca? marca = db.Marcas
                .Where(p => p.id == id)
                .FirstOrDefault();
            if (marca == null)
            {
                return NotFound(new { message = "Marca no encontrado con el id: " + id });

            }
            db.Marcas.Remove(marca);
            db.SaveChanges();
            return NoContent();

        }
    }
}
