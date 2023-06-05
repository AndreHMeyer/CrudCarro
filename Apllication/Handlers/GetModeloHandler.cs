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
    public class GetModeloHandler
    {
        private IModeloRepository modeloRepository;

        public GetModeloHandler(MySqlConnection mySqlConnection)
        {
            modeloRepository = new ModeloRepository(mySqlConnection);
        }

        public List<Modelo> Handle()
        {
            try
            {
                return modeloRepository.GetModelos().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
