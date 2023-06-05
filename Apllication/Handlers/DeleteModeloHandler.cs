﻿using Domain.Entities;
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
    public class DeleteModeloHandler
    {
        private IModeloRepository modeloRepository;

        public DeleteModeloHandler(MySqlConnection mySqlConnection)
        {
            modeloRepository = new ModeloRepository(mySqlConnection);
        }
        public Modelo Handle(Modelo modelo)
        {
            try
            {
                return modeloRepository.DeleteModelo(modelo).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
