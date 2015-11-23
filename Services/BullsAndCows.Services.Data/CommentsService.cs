namespace Teleimot.Services.Data
{
    using System.Linq;
    using Teleimot.Data.Models;
    using Teleimot.Data.Repositories;
    using Contracts;
    using System;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetCommentById(int id)
        {
            var comment = this
                            .comments
                            .All()
                            .Where(x => x.Id == id);

            return comment;
        }

        public IQueryable<Comment> GetCommentsForEstate(int id, int skip, int take)
        {
            var comment = this
                           .comments
                           .All()
                           .Where(x => x.Estate.Id == id)
                           .Skip(skip)
                           .Take(take);

            return comment;
        }

        public IQueryable<Comment> GetCommentsByUsername(string userName, int skip, int take)
        {
            var comment = this
                           .comments
                           .All()
                           .Where(x => x.UserName == userName)
                           .Skip(skip)
                           .Take(take);

            return comment;
        }

        public Comment CreateComment(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment;
        }
    }
}
