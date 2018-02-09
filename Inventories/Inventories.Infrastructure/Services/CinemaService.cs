using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Context;
using Inventories.Data.EntityFramework.Models;
using Inventories.Infrastructure.Interfaces;
using Inventories.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Infrastructure.Services
{
    public class CinemaService : GenericRepository<Cinema>, ICinemaService
    {
        public CinemaService(FoodsMxDbContext context) : base(context)
        {
        }

        public async Task<Cinema> GetAsync(string vistaId)
        {
            var query = await GetAll().FirstOrDefaultAsync(x => x.VistaId == vistaId);
            return query;
        }
    }
}
