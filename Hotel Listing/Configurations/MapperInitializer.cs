using AutoMapper;
using Hotel_Listing.Data;
using Hotel_Listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Listing.Configurations {
    public class MapperInitializer : Profile {
        public MapperInitializer() {
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Country, CreateCountryModel>().ReverseMap();
            CreateMap<Hotel, HotelModel>().ReverseMap();
            CreateMap<Hotel, CreateHotelModel>().ReverseMap();
        }
    }
}
