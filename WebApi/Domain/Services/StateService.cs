using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApi.DAL;
using WebApi.DAL.Entities;
using WebApi.Domain.Interfaces;

namespace WebApi.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;
        public StateService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            try
            {
                var states = await _context.States.ToListAsync();
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }        

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);//Permite crear el objeto en el contexto de mi BD.
                await _context.SaveChangesAsync();//Permite guardar el pais en la tabla COUNTRY.
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state); //Vitualizo el objeto
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);

                if (state == null)
                {
                    return null;
                }

                _context.States.Remove(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        

        

        
    }
}
