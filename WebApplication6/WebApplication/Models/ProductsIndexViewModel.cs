using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDAL.Models;

namespace WebApplication.Models
{
	public class ProductsIndexViewModel
	{
	public List<Product> Products { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		
	}
}
