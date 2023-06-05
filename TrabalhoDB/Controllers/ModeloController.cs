using Application.Handlers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace TrabalhoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private GetModeloHandler getModeloHandler;
        private CreateModeloHandler createModeloHandler;
        private UpdateModeloHandler updateModeloHandler;
        private DeleteModeloHandler deleteModeloHandler;

        public ModeloController(IConfiguration configuration)
        {
            MySqlConnection connection = new(configuration.GetConnectionString("trabalho06"));
            getModeloHandler = new GetModeloHandler(connection);
            createModeloHandler = new CreateModeloHandler(connection);
            updateModeloHandler = new UpdateModeloHandler(connection);
            deleteModeloHandler = new DeleteModeloHandler(connection);
        }

        [HttpGet]

        public ActionResult<List<Modelo>> GetModelo()
        {
            try
            {
                var t = getModeloHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateModelo([FromBody] Modelo modelo)
        {
            try
            {
                var t = createModeloHandler.Handle(modelo);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateModelo([FromBody] Modelo modelo)
        {
            try
            {
                var t = updateModeloHandler.Handle(modelo);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteModelo([FromBody] Modelo modelo)
        {
            try
            {
                var t = deleteModeloHandler.Handle(modelo);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
