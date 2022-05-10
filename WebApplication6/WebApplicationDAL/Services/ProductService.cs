using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDAL.Contexts;
using WebApplicationDAL.Models;

namespace WebApplicationDAL.Services
{
	public class ProductService
	{
		private int perpage = 3;
		//public List<Product> GetProducts()
		//{
		//	using (WebApplicationDbContext context = new WebApplicationDbContext())
		//	{
		//		return context.Products.ToList();
		//	}
		//}
		public List<Product> GetProducts(int? pageNullable)
		{
			using (WebApplicationDbContext context = new WebApplicationDbContext())
		   {
				int page = pageNullable != null ? pageNullable.Value : 1;
				

				return context.Products
					.Skip((page-1) * this.perpage)
				    .Take(this.perpage) 
					.ToList();
			}
		}
		public int GetTotalPages()
		{
			using (WebApplicationDbContext context = new WebApplicationDbContext())
			{
				double count = context.Products.Count();
				return(int)Math.Ceiling( count / this.perpage);
			}
		}
		public void Store(Product product)
		{
			using (WebApplicationDbContext context=new WebApplicationDbContext())
			{
				context.Products.Add(product);
				context.SaveChanges();
			}
		}
		public Product GetProductById(int id)
		{

			using (WebApplicationDbContext context = new WebApplicationDbContext())
			{
				return context.Products.Where(x => x.Id == id)
					.FirstOrDefault();
			}
		}
		public void Update(Product product)
		{
			using (WebApplicationDbContext context = new WebApplicationDbContext())
			{
				//context.Attach(product).State = EntityState.Modified;
				context.Entry(product).State = EntityState.Modified;
				context.SaveChanges();
			}
		}
		public void Delete(int id)
		{
			using (WebApplicationDbContext context = new WebApplicationDbContext())
			{
				var p = new Product() { Id = id };
				context.Attach(p).State = EntityState.Deleted;
				context.SaveChanges();
			}
		}
		
		
	}
}
