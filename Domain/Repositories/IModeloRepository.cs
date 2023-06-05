using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IModeloRepository
    {
        Task<List<Modelo>> GetModelos();
        Task<long> CreateModelo(Modelo modelo);
        Task<Modelo> UpdateModelo(Modelo modelo);
        Task<Modelo> DeleteModelo(Modelo modelo);
    }
}
