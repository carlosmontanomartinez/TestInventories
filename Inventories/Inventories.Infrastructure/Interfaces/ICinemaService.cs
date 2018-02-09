using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;

namespace Inventories.Infrastructure.Interfaces
{
    public interface ICinemaService
    {
        Task<Cinema> GetAsync(string vistaId);
    }
}
