using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary
{
    public class DataContext:DbContext
    {
        public DataContext():base()
        {}

        public DataContext(string connectionString):base(connectionString)
        {
                
        }

        public DbSet<List> ListText { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>()
                .Property(e => e.Description)
                .HasMaxLength(50);
        }
    }
}
