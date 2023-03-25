using AT.Domain;

namespace CountriesApi.Services
{
    public interface ICountriesService
    {
        Country Create(Country country);
    }
}
