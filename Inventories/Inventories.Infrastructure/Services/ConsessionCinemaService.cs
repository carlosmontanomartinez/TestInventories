using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Context;
using Inventories.Data.EntityFramework.Models;
using Inventories.Infrastructure.Interfaces;
using Inventories.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Infrastructure.Services
{
    public class ConsessionCinemaService : GenericRepository<ConcessionCinema>, IConsessionCinemaService
    {
        public ConsessionCinemaService(FoodsMxDbContext context) : base(context)
        {
        }

        public async Task<ConcessionCinema> GetAsync(int cinemaId, int hopk)
        {
            var query = await GetAll().Include(x=>x.Cinema).Include(x=>x.Status).FirstOrDefaultAsync(x=> x.CinemaId == cinemaId && x.Hopk == hopk);
            return query;
        }


    }
}
