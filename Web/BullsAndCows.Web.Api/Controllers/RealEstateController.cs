namespace Teleimot.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Models.Games;
    using System.Linq;
    using Data.Models;

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

        //[Route("RealEstates")]
        //public IHttpActionResult Get()
        //{
        //    var estates = this
        //                   .realEstates
        //                   .GetTop10()
        //                   .ProjectTo<ListedRealEstateResponseModel>();

        //    return this.Ok(estates);
        //}

        //[Authorize]
        //[Route("RealEstates/{id}")]
        //public IHttpActionResult Get(string id)
        //{
        //    int idNumber = 0;

        //    if (int.TryParse(id, out idNumber))
        //    {
        //        var result = this.realEstates.GetEstateDetails(idNumber);

        //        if (result != null)
        //        {
        //            return this.Ok(result);
        //        }
        //    }

        //    return this.BadRequest("Id is not found or invalid");
        //}

        [Authorize]
        [Route("RealEstates/{id}")]
        public IHttpActionResult Get(string id)
        {
            int idNumber = 0;

            if (int.TryParse(id, out idNumber))
            {
                var result = this.realEstates.GetEstateDetails(idNumber);

                if (result != null)
                {
                    return this.Ok(result);
                }
            }

            return this.BadRequest("Id is not found or invalid");
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

            this.realEstates.CreateEstate(estateInfo);

            var result = this.realEstates;
            var second = result.GetEstateDetails(estateInfo.Id);
            var third = second.ProjectTo<ListedRealEstateResponseModel>();
            var fourth = third.FirstOrDefault();

            return this.Created(string.Format("/api/RealEstates/{0}", estateInfo.Id), fourth);
        }
    }
}