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
    public class GetMarcaHandler
    {
        private IMarcaRepository marcaRepository;

        public GetMarcaHandler(MySqlConnection mySqlConnection)
        {
            marcaRepository = new MarcaRepository(mySqlConnection);
        }

        public List<Marca> Handle()
        {
            try
            {
                return marcaRepository.GetMarcas().Result;
            }
            catch(Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
