using WebApi.DAL.Entities;

namespace WebApi.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync(); //Firma del metodo que se encarga de decirle al servicio que liste todos los paises
        Task<State> CreateStateAsync(State state);
        Task<State> GetStateByIdAsync(Guid id);
        Task<State> EditStateAsync(State state);
        Task<State> DeleteStateAsync(Guid id);
    }
}
