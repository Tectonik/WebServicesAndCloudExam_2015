namespace Teleimot.Services.Data
{
    using System.Linq;
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

        // Nobody said /api/RealEstates?skip=S&take=T shouldn't be sorted by date & time soo....
        public IQueryable<RealEstate> GetPublicRealEstates(int skip = 0, int take = 10)
        {
            // TODO take >x 100

            var result = this
                           .realEstates
                           .All()
                           .OrderBy(estate => estate.ConstructionYear)
                           .Skip(skip)
                           .Take(take);

            return result;
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

        // TODO DO
        public IQueryable<RealEstate> GetEstateGeneralInformation(int id)
        {
            return this
                    .realEstates
                    .All()
                    .Where(estate => estate.Id == id);
        }

        //public IQueryable<RealEstate> GetTop10()
        //{
        //    var topEstates = this
        //                    .GetPublicRealEstates()
        //                    .OrderByDescending(x => x.DateTimeOfCreation)
        //                    .Take(10);

        //    return topEstates;
        //}
    }
}
