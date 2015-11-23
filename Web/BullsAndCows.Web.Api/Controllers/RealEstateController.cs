namespace Teleimot.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Models.Games;
    using System.Linq;
    using Data.Models;

    // TODO FIX THIS RETURN SHITE IN 5 MINUTES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [RoutePrefix("api")]
    public class RealEstateController : ApiController
    {
        private readonly IRealEstateService realEstates;

        public RealEstateController(IRealEstateService realEstates)
        {
            this.realEstates = realEstates;
        }

        [Route("RealEstates")]
        public IHttpActionResult Get(string skip = "0", string take = "10")
        {
            int skipNumber = -1;
            int takeNumber = -1;

            bool parametersAreNumbers = int.TryParse(skip, out skipNumber) && int.TryParse(take, out takeNumber);
            bool parametersAreValid = skipNumber >= 0 && takeNumber > 0 && takeNumber <= 100;

            if (parametersAreNumbers && parametersAreValid)
            {
                var estates = this
                                .realEstates
                                .GetPublicRealEstates(skipNumber, takeNumber)
                                .ProjectTo<ListedRealEstateResponseModel>()
                                .ToList();

                return this.Ok(estates);
            }

            return this.InternalServerError();
        }

        [Authorize]
        [Route("RealEstates")]
        public IHttpActionResult Post([FromBody] RealEstate estateInfo)
        {
            if (estateInfo == null)
            {
                return this.BadRequest("Estate info cannot be empty");
            }
            else if (this.ModelState.IsValid == false)
            {
                return this.BadRequest("Error in estate info");
            }

            var result = this.realEstates
                .GetEstateDetails(estateInfo.Id)
                .ProjectTo<ListedRealEstateResponseModel>()
                .FirstOrDefault();

            return this.Created(string.Format("/api/RealEstates/{0}", estateInfo.Id), 6);
        }
    }
}