using System.Collections.Generic;
using MRJCommerce.Models.ViewModels;
using MRJCommerce.Models;
namespace MRJCommerce.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}