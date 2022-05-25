using DotnetCoreMVC_CRUD_Async_GenericRepository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreMVC_CRUD_Async_GenericRepository.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext context;
        public ProductsController(ProductsDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var queryProducts = from p in context.Products
                                select p;
            var products = queryProducts.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product prod)
        {
            if (!ModelState.IsValid)
                return View(prod);

            context.Products.Add(prod);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var prod = context.Products.Find(id);
            if (prod == null)
                return NotFound();
            return View(prod);
        }

        public IActionResult Edit(int id)
        {
            var prod = context.Products.Find(id);
            if (prod == null)
                return NotFound();
            return View(prod);

        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            if (!ModelState.IsValid)
                return View(prod);

            context.Attach(prod);
            context.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var prod = context.Products.Find(id);
            if (prod == null)
                return NotFound();
            return View(prod);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var prod = context.Products.Find(id);
            context.Products.Remove(prod);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
