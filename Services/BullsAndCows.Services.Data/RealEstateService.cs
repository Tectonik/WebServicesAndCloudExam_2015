namespace Teleimot.Services.Data
{
    using System.Linq;
    using Common.Constants;
    using Teleimot.Data.Models;
    using Teleimot.Data.Repositories;
    using Contracts;

    public class RealEstateService : IRealEstateService
    {
        private readonly IRepository<RealEstate> realEstates;

        public RealEstateService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public IQueryable<RealEstate> GetPublicRealEstates(int skip = 0, int take = 10)
        {
            // TODO take >x 100

            var x = this
                .realEstates;

            var y = x.All();
            var z = y.OrderBy(estate => estate.TimeOfCreation);
            var m = z.Skip(skip);
            var n = m.Take(take);

            return n;
        }
    }
}
