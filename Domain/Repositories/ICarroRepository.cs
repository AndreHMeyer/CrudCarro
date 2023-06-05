using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICarroRepository
    {
        Task<List<Carro>> GetCarros();
        Task<long> CreateCarro(Carro carro);
        Task<Carro> UpdateCarro(Carro carro);
        Task<Carro> DeleteCarro(Carro carro);
    }
}
