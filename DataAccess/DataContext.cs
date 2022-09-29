using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext : DbContext
    {

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            InitialData.LoadInitialData(ref modelBuilder);
		}
	}
}
