using MRJCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MRJCommerce.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product> {
    new Product { Name = "Jacket", Price = 79 },
    new Product { Name = "Dress", Price = 179 },
    new Product { Name = "Running shoes", Price = 95 }
};
    }
}