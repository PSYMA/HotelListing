using Hotel_Listing.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Listing.Models {
    public class CreateHotelModel {
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hotel name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Address name is too long")]
        public string Address { get; set; }

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; } 
    }

    public class HotelModel : CreateHotelModel {
        public int Id { get; set; }
        public CountryModel Country { get; set; }
    }
}
