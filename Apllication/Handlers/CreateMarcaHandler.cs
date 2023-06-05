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
    public class CreateMarcaHandler
    {
        private IMarcaRepository marcaRepository;

        public CreateMarcaHandler (MySqlConnection mySqlConnection)
        {
            marcaRepository = new MarcaRepository(mySqlConnection);
        }
        public long Handle(Marca marca)
        {
            try
            {
                return marcaRepository.CreateMarca(marca).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
