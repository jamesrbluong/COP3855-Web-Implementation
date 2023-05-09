using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
   
    public class AuctionController : Controller
    {
        private IAuctionRepository repository;
        private IProductRepository productRepository;

        public AuctionController(IAuctionRepository repo, IProductRepository productRepo)
        {
            repository = repo;
            productRepository = productRepo;
        }

        public ViewResult Index() => View(repository.Auctions);

        public ViewResult Create() => View("Edit", new Auction());

        [HttpPost]
        public IActionResult Create(Auction auction)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAuction(auction);
                TempData["message"] = $"{auction.Product.Name} auction has been created";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View("Edit", auction);
            }
        }

        public ViewResult Edit(int auctionID) =>
            View(repository.Auctions.FirstOrDefault(a => a.AuctionID == auctionID));

        [HttpPost]
        public IActionResult Edit(Auction auction)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAuction(auction);
                TempData["message"] = $"{auction.Product.Name} auction has been updated";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(auction);
            }
        }

        [HttpPost]
        public IActionResult Delete(int auctionID)
        {
            Auction deletedAuction = repository.DeleteAuction(auctionID);
            if (deletedAuction != null)
            {
                TempData["message"] = $"{deletedAuction.Product.Name} auction was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
