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
    public class StatusService : GenericRepository<Status>, IStatusService
    {
        public StatusService(FoodsMxDbContext context) : base(context)
        {
        }

        public async Task<Status> GetAsync(string code)
        {
            var query = await GetAll().FirstOrDefaultAsync(x => x.Code == code);
            return query;
        }
    }
}
