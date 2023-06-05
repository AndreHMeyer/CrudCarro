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
    public class UpdateMarcaHandler
    {
        private IMarcaRepository marcaRepository;

        public UpdateMarcaHandler(MySqlConnection mySqlConnection)
        {
            marcaRepository = new MarcaRepository(mySqlConnection);
        }
        public Marca Handle(Marca marca)
        {
            try
            {
                return marcaRepository.UpdateMarca(marca).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
