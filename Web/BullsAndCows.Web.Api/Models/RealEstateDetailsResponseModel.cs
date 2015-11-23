namespace Teleimot.Web.Api.Models
{
    using AutoMapper;
    using System;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RealEstateDetailsResponseModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateDetailsResponseModel>()
                .ForMember(g => g.Id, opts => opts.MapFrom(g => g.Id))
                .ForMember(g => g.Title, opts => opts.MapFrom(g => g.Title))
                .ForMember(g => g.SellingPrice, opts => opts.MapFrom(g => g.SellingPrice.ToString()))
                .ForMember(g => g.RentingPrice, opts => opts.MapFrom(g => g.RentingPrice.ToString()))
                .ForMember(g => g.CanBeSold, opts => opts.MapFrom(g => g.CanBeSold))
                .ForMember(g => g.CanBeRented, opts => opts.MapFrom(g => g.CanBeRented));
        }
    }
}