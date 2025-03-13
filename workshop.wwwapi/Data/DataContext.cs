using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using workshop.models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Calculation> Calculations { get; set; }
    }
}
