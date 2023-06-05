using Dapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private IDbConnection connection;

        public ModeloRepository(IDbConnection con)
        {
            this.connection = con;
        }

        public async Task<List<Modelo>> GetModelos()
        {
            try
            {
                StringBuilder query = new();
                query.Append("SELECT m.id as Id, ");
                query.Append("m.nome as Nome, ");
                query.Append("m.idMarca as IdMarca ");
                query.Append("FROM modelo m ");
                query.Append("JOIN marca mr ON mr.id = m.idMarca;");

                var obj = await connection.QueryAsync<Modelo>(query.ToString());

                return obj.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<long> CreateModelo(Modelo modelo)
        {
            try
            {
                StringBuilder query = new();
                query.Append("INSERT INTO modelo (nome, idMarca) ");
                query.Append("VALUES (@nome, @idMarca); ");
                query.Append("SELECT LAST_INSERT_ID();");

                var parameters = new
                {
                    nome = modelo.Nome,
                    idMarca = modelo.IdMarca
                };

                var result = await connection.QueryAsync<long>(query.ToString(), parameters);

                return result.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<Modelo> UpdateModelo(Modelo modelo)
        {
            try
            {
                StringBuilder query = new();
                query.Append("UPDATE modelo SET nome = @nome ");
                query.Append("WHERE id = @id;");

                var parameters = new
                {
                    id = modelo.Id,
                    nome = modelo.Nome
                };

                await connection.ExecuteAsync(query.ToString(), parameters);

                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<Modelo> DeleteModelo(Modelo modelo)
        {
            try
            {
                StringBuilder query = new();
                query.Append("DELETE FROM modelo WHERE id = @id;");

                var parameters = new
                {
                    id = modelo.Id
                };

                await connection.ExecuteAsync(query.ToString(), parameters);

                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }
    }
}
