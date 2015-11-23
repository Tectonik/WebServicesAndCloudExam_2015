namespace Teleimot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Enumerations;

    public class RealEstate
    {
        // Creation of the advertisement, not the building, right?
        public RealEstate(DateTime dateTimeOfCreation)
        {
            this.DateTimeOfCreation = dateTimeOfCreation;
        }

        public int Id { get; set; }

        public RealEstateType Type { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        public decimal SellingPrice { get; set; }

        // TODO State validation, 2 or 1, not 0
        public decimal RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        [Range(1800, int.MaxValue)]
        public int ConstructionYear { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        public ICollection<Rating> Rating { get; set; }

        [MinLength(10)]
        [MaxLength(500)]
        public ICollection<Comment> Comments { get; set; }

        public DateTime DateTimeOfCreation { get; set; }
    }
}
