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
    public class CreateModeloHandler
    {
        private IModeloRepository modeloRepository;

        public CreateModeloHandler(MySqlConnection mySqlConnection)
        {
            modeloRepository = new ModeloRepository(mySqlConnection);
        }
        public long Handle(Modelo modelo)
        {
            try
            {
                return modeloRepository.CreateModelo(modelo).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
