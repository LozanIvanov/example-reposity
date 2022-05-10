using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplicationDAL.Models;
using WebApplicationDAL.Services;

namespace WebApplication.Controllers
{
	public class ProductController:Controller
	{
		private ProductService service;

		public ProductController()
		{
			this.service = new ProductService();
		}
		//public IActionResult Index()
		//{
			//var model = new ProductsIndexViewModel()
			//{
		//		Products = this.service.GetProducts()
		//    };
		//	return View(model);
		//}
		public IActionResult Index(int? page)
		{
			var model = new ProductsIndexViewModel()
			{
				Products = this.service.GetProducts(page),
				TotalPages = this.service.GetTotalPages(),
				CurrentPage = page != null ? page.Value : 1
			};
			return View(model);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Store(Product product)
		{
			this.service.Store(product);
			return RedirectToAction("Create");
		}
		public IActionResult Edit(int id)
		{
			Product product = this.service.GetProductById(id);
			if (product == null)
			{
				return Redirect("404");
			}
			return View(product);
		}
		[HttpPost]
		public IActionResult Update(Product product)
		{
			this.service.Update(product);
			return Redirect("/Product");
		}
		[HttpPost]


		public IActionResult Delete(int id)
		{
			this.service.Delete(id);
			return Redirect("/Product");
		}
	}
}
