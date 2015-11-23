namespace Teleimot.Web.Api.Models
{
    using System;
    using Data.Models;
    using AutoMapper;
    using Infrastructure.Mappings;

    public class ListedCommentResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, ListedCommentResponseModel>()
                .ForMember(comment => comment.Content, opts => opts.MapFrom(g => g.Content))
                .ForMember(comment => comment.UserName, opts => opts.MapFrom(g => g.UserName))
                .ForMember(comment => comment.CreatedOn, opts => opts.MapFrom(g => g.CreatedOn.ToString()));
        }
    }
}