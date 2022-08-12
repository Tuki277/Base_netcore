using api_base.Models;

namespace api_base.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);

        Country GetCountryByOwner(int ownerId);

        ICollection<Owner> GetOwnersFromACountry(int CountryId);

        bool CountryExists(int id);
    }
}