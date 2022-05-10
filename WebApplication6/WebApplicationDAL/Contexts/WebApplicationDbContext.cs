using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDAL.Models;

namespace WebApplicationDAL.Contexts
{
	class WebApplicationDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.;Database=MyShop;Trusted_Connection=true");
				
			}
			base.OnConfiguring(optionsBuilder);
		}
	}
}
