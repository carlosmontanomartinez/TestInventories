using System;
using System.Collections.Generic;
using System.Text;
using Inventories.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inventories.Data.EntityFramework.Factories
{
    public class FoodsMxFactory : IDesignTimeDbContextFactory<FoodsMxDbContext>
    {
        public FoodsMxDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<FoodsMxDbContext>();
            optionsBuilder.UseSqlServer(@"Server=
             (localdb)\MSSQLLocalDB;Database=TicTacToe;
             Trusted_Connection=True;MultipleActiveResultSets=true");
            return new FoodsMxDbContext(optionsBuilder.Options);
        }
    }
}
