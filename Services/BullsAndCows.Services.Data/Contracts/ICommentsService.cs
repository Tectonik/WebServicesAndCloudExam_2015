namespace Teleimot.Services.Data.Contracts
{
    using System.Linq;
    using Teleimot.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetCommentsForEstate(int id, int skip, int take);

        IQueryable<Comment> GetCommentsByUsername(string userName, int skip, int take);

        Comment CreateComment(Comment comment);

        IQueryable<Comment> GetCommentById(int id);
    }
}