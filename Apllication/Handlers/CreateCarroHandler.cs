using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateCarroHandler
    {
        private ICarroRepository carroRepository;

        public CreateCarroHandler(MySqlConnection mySqlConnection)
        {
            carroRepository = new CarroRepository(mySqlConnection);
        }
        public long Handle(Carro carro)
        {
            try
            {
                return carroRepository.CreateCarro(carro).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
