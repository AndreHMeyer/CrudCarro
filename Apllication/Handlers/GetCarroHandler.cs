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
    public class GetCarroHandler
    {
        private ICarroRepository carroRepository;

        public GetCarroHandler(MySqlConnection mySqlConnection)
        {
            carroRepository = new CarroRepository(mySqlConnection);
        }

        public List<Carro> Handle()
        {
            try
            {
                return carroRepository.GetCarros().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
