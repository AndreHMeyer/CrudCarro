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
    public class DeleteMarcaHandler
    {
        private IMarcaRepository marcaRepository;

        public DeleteMarcaHandler(MySqlConnection mySqlConnection)
        {
            marcaRepository = new MarcaRepository(mySqlConnection);
        }
        public Marca Handle(Marca marca)
        {
            try
            {
                return marcaRepository.DeleteMarca(marca).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
