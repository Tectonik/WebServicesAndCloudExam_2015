namespace Teleimot.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using System.Web.Http;
    using Teleimot.Services.Data.Contracts;
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
            //return this.Created<string>("", "");
            return this.Ok(estateInfo);
        }
    }
}