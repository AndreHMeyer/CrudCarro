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
    public class CarroController : ControllerBase
    {
        private GetCarroHandler getCarroHandler;
        private CreateCarroHandler createCarroHandler;
        private UpdateCarroHandler updateCarroHandler;
        private DeleteCarroHandler deleteCarroHandler;

        public CarroController(IConfiguration configuration)
        {
            MySqlConnection connection = new(configuration.GetConnectionString("trabalho06"));
            getCarroHandler = new GetCarroHandler(connection);
            createCarroHandler = new CreateCarroHandler(connection);
            updateCarroHandler = new UpdateCarroHandler(connection);
            deleteCarroHandler = new DeleteCarroHandler(connection);
        }

        [HttpGet]

        public ActionResult<List<Carro>> GetCarro()
        {
            try
            {
                var t = getCarroHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateCarro([FromBody] Carro carro)
        {
            try
            {
                var t = createCarroHandler.Handle(carro);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateCarro([FromBody] Carro carro)
        {
            try
            {
                var t = updateCarroHandler.Handle(carro);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteCarro([FromBody] Carro carro)
        {
            try
            {
                var t = deleteCarroHandler.Handle(carro);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
