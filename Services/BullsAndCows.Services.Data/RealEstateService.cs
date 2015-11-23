namespace Teleimot.Services.Data
{
    using System.Linq;
    using Common.Constants;
    using Teleimot.Data.Models;
    using Teleimot.Data.Repositories;
    using Contracts;
    using System;

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

        public RealEstate CreateEstate(RealEstate estate)
        {
            this.realEstates.Add(estate);
            this.realEstates.SaveChanges();

            return estate;
        }

        public IQueryable<RealEstate> GetEstateDetails(int id)
        {
            return this
                    .realEstates
                    .All()
                    .Where(estate => estate.Id == id);
        }
    }
}
