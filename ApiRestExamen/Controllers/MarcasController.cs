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
    }
}
