using DataAccess.Entites;
using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class InitialData
	{
		internal static void LoadInitialData(ref ModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<Role>().HasData(
				new Role 
				{
					Id=1,
					Name="Admin",
					CreatedAt=DateTime.Now,
					CreatedUser = 1					
				});

			
			var salt = Crypto.GenerateSalt();

			modelBuilder.Entity<Role>().HasData(
				new User
				{
					Id = 1,
					Email = "admin@example.com",
					RoleId = 1,
					Username = "Admin",
					Salt = salt,
					PasswordHash = Crypto.GenerateSHA256Hash("admin",salt),
					CreatedAt = DateTime.Now,
					CreatedUser = 1					
				});;;

		}
	}
}
