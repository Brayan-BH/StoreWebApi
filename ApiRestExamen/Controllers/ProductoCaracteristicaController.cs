using ApiRestExamen.MyDb.Contexts;
using ApiRestExamen.MyDb.Tablas;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestExamen.Controllers
{
    [Controller]
    [Route("/api/v1/producto")]
    public class ProductoCaracteristicaController: ControllerBase
    {
        private readonly MyDbContext db;
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        public ProductoCaracteristicaController (MyDbContext context)
        {
            db = context;
        }
        //EndPoint
        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<ProductoCaracteristica> productoCaracteristica = db.ProductoCaracteristica.ToList();
            return Ok(productoCaracteristica);

        }
        //get by id only one
        [HttpGet]
        [Route("{productoId}/caracteristica")]
        public ActionResult ObtenerPorId([FromRoute] int productoId)
        {

            var productoCaracteristica = db.ProductoCaracteristica
                .Where(p => p.producto_id == productoId);

            if (productoCaracteristica == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + productoId });

            }
            return Ok(productoCaracteristica);

        }

        //Registrar
        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] ProductoCaracteristica productoCaracteristica)
        {
            db.ProductoCaracteristica.Add(productoCaracteristica);
            db.SaveChanges();
            return Ok(productoCaracteristica);

        }

        //Actualizar 
        [HttpPut]
        [Route("{productoId}/caracteristica/{caracteristicaId}")]
        public ActionResult Actualizar([FromRoute] int productoId, [FromBody] ProductoCaracteristica productoCaracteristicaDatos)
        {
            ProductoCaracteristica? productoCaracteristica = db.ProductoCaracteristica
                .Where(pc => pc.producto_id == productoId)
                .FirstOrDefault();
            if (productoCaracteristica == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + productoId });

            }
            productoCaracteristica.nombre = productoCaracteristicaDatos.nombre;
            productoCaracteristica.descripcion = productoCaracteristicaDatos.descripcion;
            //productoCaracteristica.producto_id = productoCaracteristicaDatos.producto_id;
            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            ProductoCaracteristica? productoCaracteristica = db.ProductoCaracteristica
                  .Where(pc => pc.id == id)
                  .FirstOrDefault();
            if (productoCaracteristica == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + id });

            }
            db.ProductoCaracteristica.Remove(productoCaracteristica);
            db.SaveChanges();
            return NoContent();

        }
    }
}
