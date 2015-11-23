namespace Teleimot.Web.Api.Models.Games
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ListedRealEstateResponseModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        //public DateTime TimeOfCreation { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, ListedRealEstateResponseModel>()
                .ForMember(estate => estate.Id, x => x.MapFrom(g => g.Id))
                .ForMember(estate => estate.Title, x => x.MapFrom(g => g.Title))
                .ForMember(estate => estate.SellingPrice, x => x.MapFrom(g => g.SellingPrice))
                .ForMember(estate => estate.RentingPrice, x => x.MapFrom(g => g.RentingPrice))
                .ForMember(estate => estate.CanBeSold, x => x.MapFrom(g => g.CanBeSold))
                .ForMember(estate => estate.CanBeRented, x => x.MapFrom(g => g.CanBeRented));

            //.ForMember(estate => estate.Red, iSomethingyIvoDid => iSomethingyIvoDid.MapFrom(g => g.RedUser.Email))
            //.ForMember(estate => estate.GameState, thisToo => thisToo.MapFrom(g => g.GameState.ToString()));
        }
    }
}