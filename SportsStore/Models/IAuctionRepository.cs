using System.Collections.Generic;

namespace SportsStore.Models
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> Auctions { get; }
        void SaveAuction(Auction auction);
        Auction DeleteAuction(int auctionID);
    }
}
