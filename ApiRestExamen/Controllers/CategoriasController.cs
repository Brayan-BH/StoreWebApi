using ApiRestExamen.MyDb.Contexts;
using ApiRestExamen.MyDb.Tablas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestExamen.Controllers
{
    [Controller]
    [Route("/api/v1/categorias")]
    public class CategoriasController: ControllerBase
    {
        private readonly MyDbContext db;
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        public CategoriasController (MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<Categoria> categorias = db.Categorias.ToList();
            return Ok(categorias);
        }

        [HttpGet]
        [Route("{id}/productos")]

        public ActionResult ListarOne([FromRoute] int id)
        {

            var producto = db.Productos
                .Where(p => p.categoria_id == id);

            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + id });

            }

            return Ok(producto);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Categoria categoria)
        {
            db.Categorias.Add(categoria);
            db.SaveChanges();
            return Ok(categoria);

        }



        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Categoria categoriaDatos)
        {
            Categoria? categoria = db.Categorias
                .Where(p => p.id == id)
                .FirstOrDefault();
            if (categoria == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            categoria.nombre = categoriaDatos.nombre;
            categoria.categoria_padre = categoriaDatos.categoria_padre;

            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            Categoria? categoria = db.Categorias
                .Where(p => p.id == id)
                .FirstOrDefault();
            if (categoria == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return NoContent();

        }
    }
}
