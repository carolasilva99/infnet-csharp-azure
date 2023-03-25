using AT.Domain;
using AutoMapper;
using CountriesApi.DTOs;

namespace CountriesApi.Mapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountryDto, Country>();
        }
    }
}
