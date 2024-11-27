using Microsoft.AspNetCore.Mvc;
using WebApi.DAL.Entities;
using WebApi.Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")] //Este es el nombre inicial de mi ruta, url o path. (La que va en el browser).
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetStatesAsync()
        {
            var states = await _stateService.GetStatesAsync();

            if (states == null || !states.Any())
            {
                return NotFound();
            }

            return Ok(states);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL => api/states/get
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);

            if (state == null)
            {
                return NotFound(); //NotFound = Status code 404
            }

            return Ok(state); //OK = Status code 200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) { return NotFound(); } //Validar que el codigo no sea nulleable
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                if (editedState == null) { return NotFound(); }
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) { return NotFound(); }
            return Ok(deletedState);
        }
    }
}
