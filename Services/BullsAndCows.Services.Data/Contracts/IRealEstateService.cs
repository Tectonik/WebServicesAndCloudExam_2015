using System.Linq;
using Teleimot.Data.Models;

namespace Teleimot.Services.Data.Contracts
{
    public interface IRealEstateService
    {
        IQueryable<RealEstate> GetPublicRealEstates(int skip = 0, int take = 10);
    }
}