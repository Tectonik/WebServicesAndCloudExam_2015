namespace Teleimot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enumerations;
    using System.Collections.Generic;

    public class RealEstate
    {
        public int Id { get; set; }

        public RealEstateType Type { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        public decimal SellingPrice { get; set; }

        // TODO State validation
        public decimal RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        // TODO Validation
        public DateTime TimeOfCreation { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Range(1, 5)]
        public ICollection<int> Rating { get; set; }

        [MinLength(10)]
        [MaxLength(500)]
        public ICollection<string> Comments { get; set; }
    }
}
