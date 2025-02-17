using Microsoft.AspNetCore.Mvc;
using RentApp.Models.ViewModel;
using RentApp.Services.Implementation;
using RentApp.Services.Interface;

namespace RentApp.API.Controllers
{
    public class RidecarController : ControllerBase
    {
        private readonly IRidecarServices _ridecarService;
        public RidecarController(IRidecarServices ridecarService)
        {
            _ridecarService = ridecarService;
        }
        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll()
        {
            List<RidecarModel> ridecars = await _ridecarService.GetAll();
            return Ok(ridecars);
        }

        [HttpGet("getById/{{id}}")]

        public IActionResult GetById(Guid id)
        {

            RidecarModel ridecars = _ridecarService.GetById(id);
            return Ok(ridecars);
        }
        [HttpPost("CreateRidecar")]
        public async Task<IActionResult> CreateRidecar([FromBody] RidecarModel ridecarModel)
        {
            if (ridecarModel == null)
            {
                return BadRequest("User data is required.");
            }
            RidecarModel createdRidecar = await _ridecarService.CreateRidecar(ridecarModel);
            return CreatedAtAction(nameof(GetById), new { id = createdRidecar.Carid }, createdRidecar);
        }
        [HttpDelete("deleteById/{{id}}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isDeleted = await _ridecarService.DeleteById(id);
            if (!isDeleted)
            {
                return NotFound("User not found.");
            }
            return NoContent();
        }
    }
}
