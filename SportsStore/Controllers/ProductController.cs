using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
            .Where(p => category == null || p.Category == category)
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
       .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?
 repository.Products.Count() :
repository.Products.Where(e =>
 e.Category == category).Count()
            },
            CurrentCategory = category
        });

        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToAction("List");
            }

            var searchResults = repository.Products
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.ProductID)
                .ToList();

            return View("List", new ProductsListViewModel
            {
                Products = searchResults,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = searchResults.Count,
                    TotalItems = searchResults.Count
                },
                CurrentCategory = null
            });
        }

        [HttpPost]
        public IActionResult Filter(string[] categories)
        {
            IQueryable<Product> products;

            // If there are no categories selected when "All" is selected when filtering, return a page with products
            if (categories == null || !categories.Any() || categories.Contains(""))
            {
                products = repository.Products.AsQueryable();
            }
            else
            {
                products = repository.Products
                    .AsQueryable() 
                    .Where(p => categories.Contains(p.Category));
            }

            var orderedProducts = products
                .OrderBy(p => p.ProductID)
                .ToList();

            return View("List", new ProductsListViewModel
            {
                Products = orderedProducts,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = orderedProducts.Count,
                    TotalItems = orderedProducts.Count
                },
                CurrentCategory = null
            });
        }



    }
}
