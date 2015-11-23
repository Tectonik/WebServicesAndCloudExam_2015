using System.Linq;
using Teleimot.Data.Models;

namespace Teleimot.Services.Data.Contracts
{
    public interface IRealEstateService
    {
        IQueryable<RealEstate> GetPublicRealEstates(int skip = 0, int take = 10);

        RealEstate CreateEstate(RealEstate estate);

        IQueryable<RealEstate> GetEstateDetails(int id);
    }
}