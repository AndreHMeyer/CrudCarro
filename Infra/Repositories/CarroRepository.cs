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
    public class CarroRepository : ICarroRepository
    {
        private IDbConnection connection;

        public CarroRepository(IDbConnection con)
        {
            this.connection = con;
        }

        public async Task<List<Carro>> GetCarros()
        {
            try
            {
                StringBuilder query = new();
                query.Append("SELECT c.id as Id, ");
                query.Append("c.nome as Nome, ");
                query.Append("c.renavam as Renavam, ");
                query.Append("c.placa as Placa, ");
                query.Append("c.valor as Valor, ");
                query.Append("c.ano as Ano, ");
                query.Append("c.idModelo as IdModelo ");
                query.Append("FROM carro c ");
                query.Append("JOIN modelo m ON m.id = c.idModelo;");

                var obj = await connection.QueryAsync<Carro>(query.ToString());

                return obj.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
        }

        public async Task<long> CreateCarro(Carro carro)
        {
            try
            {
                StringBuilder query = new();
                query.Append("INSERT INTO carro (nome, renavam, placa, valor, ano, idModelo) ");
                query.Append("VALUES (@nome, @renavam, @placa, @valor, @ano, @idModelo); ");
                query.Append("SELECT LAST_INSERT_ID();");

                var parameters = new
                {
                    nome = carro.Nome,
                    renavam = carro.Renavam,
                    placa = carro.Placa,
                    valor = carro.Valor,
                    ano = carro.Ano,
                    idModelo = carro.IdModelo
                };

                var result = await connection.QueryAsync<long>(query.ToString(), parameters);

                return result.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
        }

        public async Task<Carro> UpdateCarro(Carro carro)
        {
            try
            {
                StringBuilder query = new();
                query.Append("UPDATE carro SET nome = @nome, renavam = @renavam, placa = @placa, valor = @valor, ano = @ano ");
                query.Append("WHERE id = @id;");

                var parameters = new
                {
                    id = carro.Id,
                    nome = carro.Nome,
                    renavam = carro.Renavam,
                    placa = carro.Placa,
                    valor = carro.Valor,
                    ano = carro.Ano
                };

                await connection.ExecuteAsync(query.ToString(), parameters);

                return carro;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
        }

        public async Task<Carro> DeleteCarro(Carro carro)
        {
            try
            {
                StringBuilder query = new();
                query.Append("DELETE FROM carro WHERE id = @id;");

                var parameters = new
                {
                    id = carro.Id
                };

                await connection.ExecuteAsync(query.ToString(), parameters);

                return carro;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
        }
    }
}
