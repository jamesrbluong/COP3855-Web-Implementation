using System.Linq;

namespace SportsStore.Models
{
    public class EFAuctionRepository : IAuctionRepository
    {
        private ApplicationDbContext context;

        public EFAuctionRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Auction> Auctions => context.Auctions;

        public void SaveAuction(Auction auction)
        {
            if (auction.AuctionID == 0)
            {
                context.Auctions.Add(auction);
            }
            else
            {
                Auction dbEntry = context.Auctions
                .FirstOrDefault(a => a.AuctionID == auction.AuctionID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = auction.ProductID;
                    dbEntry.StartingPrice = auction.StartingPrice;
                    dbEntry.MinimumBid = auction.MinimumBid;
                    dbEntry.CurrentPrice = auction.CurrentPrice;
                    dbEntry.StartDateTime = auction.StartDateTime; 
                    dbEntry.EndDateTime = auction.EndDateTime; 
                }
            }
            context.SaveChanges();
        }

        public Auction DeleteAuction(int auctionID)
        {
            Auction dbEntry = context.Auctions
            .FirstOrDefault(a => a.AuctionID == auctionID);
            if (dbEntry != null)
            {
                context.Auctions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
