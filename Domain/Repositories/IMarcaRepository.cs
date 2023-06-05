using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMarcaRepository
    {
        Task<List<Marca>> GetMarcas();
        Task<long> CreateMarca(Marca marca);
        Task<Marca> UpdateMarca(Marca marca);
        Task<Marca> DeleteMarca(Marca marca);
    }
}
