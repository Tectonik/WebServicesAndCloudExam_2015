namespace Teleimot.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Services.Data.Contracts;
    using Data.Models;
    using Models;
    using AutoMapper.QueryableExtensions;
    using System;

    [RoutePrefix("api")]
    public class CommentsController : ApiController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        [Authorize]
        [Route("Comments/{id}")]
        [HttpGet]
        public IHttpActionResult GetCommentsByEstateId(string id, string skip = "0", string take = "10")
        {
            var idNumber = 0;
            var skipNumber = 0;
            var takeNumber = 0;

            if (int.TryParse(id, out idNumber)
                && int.TryParse(skip, out skipNumber)
                && int.TryParse(take, out takeNumber)
                && takeNumber <= 100)
            {
                var result = this
                            .comments
                            .GetCommentsForEstate(idNumber, skipNumber, takeNumber);

                if (result != null)
                {
                    return this.Ok(result);
                }
            }

            return this.BadRequest("Invalid request");
        }

        [Authorize]
        [Route("Comments/ByUser/{userName}")]
        [HttpGet]
        public IHttpActionResult GetCommentsByUsername(string userName, string skip = "0", string take = "10")
        {
            var skipNumber = 0;
            var takeNumber = 0;

            if (int.TryParse(skip, out skipNumber)
                && int.TryParse(take, out takeNumber))
            {
                var result = this.comments.GetCommentsByUsername(userName, skipNumber, takeNumber);

                if (result != null)
                {
                    return this.Ok(result);
                }
            }

            return this.BadRequest(string.Format("Comments by user {0} not found", userName));
        }

        [Authorize]
        [Route("Comments")]
        public IHttpActionResult Post([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return this.BadRequest("comment cannot be empty");
            }
            else if (this.ModelState.IsValid == false)
            {
                return this.BadRequest("Error in comment info");
            }
            else if (comment.Content == null
                    || comment.UserName == null)
            {
                return this.BadRequest("Error in comment info");
            }

            comment.CreatedOn = DateTime.UtcNow;
            this.comments.CreateComment(comment);

            var result = this.comments
                        .GetCommentById(comment.Id)
                        .ProjectTo<ListedCommentResponseModel>()
                        .FirstOrDefault();

            return this.Created(string.Format("/api/Comments/{0}", comment.Id), result);
        }
    }
}