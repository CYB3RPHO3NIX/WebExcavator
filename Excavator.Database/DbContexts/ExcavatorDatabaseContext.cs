using Excavator.Database.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Database.DbContexts
{
    public class ExcavatorDatabaseContext : DbContext
    {
        public ExcavatorDatabaseContext(DbContextOptions<ExcavatorDatabaseContext> options) : base(options) 
        { }

        public DbSet<Setting> Settings { get; set; }
    }
}
