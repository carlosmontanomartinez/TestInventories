using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;

namespace Inventories.Infrastructure.Interfaces
{
    public interface IConsessionCinemaService : IGenericRepository<ConcessionCinema>
    {
        Task<ConcessionCinema> GetAsync(int cinemaId, int hopk);
    }
}
