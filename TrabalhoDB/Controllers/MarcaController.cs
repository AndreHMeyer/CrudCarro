using Application.Handlers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace TrabalhoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private GetMarcaHandler getMarcaHandler;
        private CreateMarcaHandler createMarcaHandler;
        private UpdateMarcaHandler updateMarcaHandler;
        private DeleteMarcaHandler deleteMarcaHandler;

        public MarcaController(IConfiguration configuration)
        {
            MySqlConnection connection = new(configuration.GetConnectionString("trabalho06"));
            getMarcaHandler = new GetMarcaHandler(connection);
            createMarcaHandler = new CreateMarcaHandler(connection);
            updateMarcaHandler = new UpdateMarcaHandler(connection);
            deleteMarcaHandler = new DeleteMarcaHandler(connection);
        }

        [HttpGet]

        public ActionResult<List<Marca>> GetMarca()
        {
            try
            {
                var t = getMarcaHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateMarca([FromBody] Marca marca)
        {
            try
            {
                var t = createMarcaHandler.Handle(marca);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateMarca([FromBody] Marca marca)
        {
            try
            {
                var t = updateMarcaHandler.Handle(marca);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteMarca([FromBody] Marca marca)
        {
            try
            {
                var t = deleteMarcaHandler.Handle(marca);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
