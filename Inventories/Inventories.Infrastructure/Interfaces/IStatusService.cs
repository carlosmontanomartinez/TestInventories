using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;

namespace Inventories.Infrastructure.Interfaces
{
    public interface IStatusService : IGenericRepository<Status>
    {
        Task<Status> GetAsync(string code);
    }
}
