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
    public class MarcaRepository : IMarcaRepository
    {
        private IDbConnection connection;

        public MarcaRepository(IDbConnection con)
        {
            this.connection = con;
        }

        public async Task<List<Marca>> GetMarcas()
        {
            try
            {
                StringBuilder query = new();
                query.Append("SELECT id as Id, ");
                query.Append("nome as Nome ");
                query.Append("FROM marca;");

                var obj = await connection.QueryAsync<Marca>(query.ToString());

                return obj.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<long> CreateMarca(Marca marca)
        {
            try
            {
                StringBuilder query = new();
                query.Append("INSERT INTO marca (nome) ");
                query.Append("VALUES (@nome); ");
                query.Append("SELECT LAST_INSERT_ID();");

                var parameters = new
                {
                    nome = marca.Nome
                };

                var result = await connection.QueryAsync<long>(query.ToString(), parameters);

                return result.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<Marca> UpdateMarca(Marca marca)
        {
            try
            {
                StringBuilder query = new();
                query.Append("UPDATE marca SET nome = @nome ");
                query.Append("WHERE id = @id;");

                var parameters = new
                {
                    id = marca.Id,
                    nome = marca.Nome
                };

                await connection.ExecuteAsync(query.ToString(), parameters);

                return marca;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<Marca> DeleteMarca(Marca marca)
        {
            try
            {
                StringBuilder query = new();
                query.Append("DELETE FROM marca WHERE id = @id;");

                var parameters = new
                {
                    id = marca.Id
                };

                await connection.ExecuteAsync(query.ToString(), parameters);

                return marca;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }
    }
}
