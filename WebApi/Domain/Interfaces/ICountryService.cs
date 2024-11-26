using System.Collections;
using WebApi.DAL.Entities;

namespace WebApi.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); //Firma del metodo que se encarga de decirle al servicio que liste todos los paises
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryById(Guid id);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}
