using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class DeleteCarroHandler
    {
        private ICarroRepository carroRepository;

        public DeleteCarroHandler(MySqlConnection mySqlConnection)
        {
            carroRepository = new CarroRepository(mySqlConnection);
        }
        public Carro Handle(Carro carro)
        {
            try
            {
                return carroRepository.DeleteCarro(carro).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
