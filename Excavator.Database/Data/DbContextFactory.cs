using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Database.Data
{
    public abstract class DbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            return CreateDbContext(GetConnectionString());
        }

        public abstract TContext CreateDbContext(string connectionString);

        protected virtual string GetConnectionString()
        {
            // Default implementation - can be overridden
            return "Data Source=THINKPAD\\THINKSERVER;Initial Catalog=WebExcavator;Integrated Security=True;Trust Server Certificate=True";
        }
    }
}
