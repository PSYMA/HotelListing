using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Listing.Models {
    public class CreateCountryModel {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Short country name is too long")]
        public string ShortName { get; set; }
    }

    public class CountryModel : CreateCountryModel {
        public int Id { get; set; }
        public IList<HotelModel> Hotels { get; set; }
    } 
}
