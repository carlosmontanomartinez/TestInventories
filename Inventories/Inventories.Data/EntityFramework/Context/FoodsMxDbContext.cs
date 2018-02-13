using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inventories.Data.EntityFramework.Models;

namespace Inventories.Data.EntityFramework.Context
{
    public class FoodsMxDbContext : DbContext
    {
        public virtual DbSet<ConsessionCinema> Concession_Cinema { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<PromotionPrice> PromotionPrice { get; set; }

        public FoodsMxDbContext(DbContextOptions<FoodsMxDbContext>
            dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
