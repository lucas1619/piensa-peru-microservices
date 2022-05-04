using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Services;
using PiensaPeru.UsersService.Extensions;
using PiensaPeru.UsersService.Resources;

namespace PiensaPeru.UsersService.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class UserCalificationsController : ControllerBase
    {
        private readonly ICalificationService _calificationService;
        private readonly IMapper _mapper;

        public UserCalificationsController(ICalificationService calificationService, IMapper mapper)
        {
            _calificationService = calificationService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<CalificationResource>), 200)]
        //public async Task<IEnumerable<CalificationResource>> GetAllAsync()
        //{
        //    var califications = await _calificationService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Calification>, IEnumerable<CalificationResource>>(califications);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CalificationResource>), 200)]
        public async Task<IEnumerable<CalificationResource>> GetAllByUserIdAsync(int userId)
        {
            var califications = await _calificationService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Calification>, IEnumerable<CalificationResource>>(califications);
            return resources;
        }

        [HttpGet("{calificationId}")]
        [ProducesResponseType(typeof(CalificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int calificationId)
        {
            var result = await _calificationService.GetByIdAsync(calificationId);
            if (!result.Success)
                return BadRequest(result.Message);
            var calificationResource = _mapper.Map<Calification, CalificationResource>(result.Resource);
            return Ok(calificationResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CalificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int userId, [FromBody] SaveCalificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var calification = _mapper.Map<SaveCalificationResource, Calification>(resource);
            var result = await _calificationService.SaveAsync(userId, calification);

            if (!result.Success)
                return BadRequest(result.Message);

            var calificationResource = _mapper.Map<Calification, CalificationResource>(result.Resource);
            return Ok(calificationResource);
        }

        [HttpPut("{calificationId}")]
        [ProducesResponseType(typeof(CalificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int calificationId, [FromBody] SaveCalificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var calification = _mapper.Map<SaveCalificationResource, Calification>(resource);
            var result = await _calificationService.UpdateAsync(calificationId, calification);

            if (!result.Success)
                return BadRequest(result.Message);

            var calificationResource = _mapper.Map<Calification, CalificationResource>(result.Resource);
            return Ok(calificationResource);
        }

        [HttpDelete("{calificationId}")]
        [ProducesResponseType(typeof(CalificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int calificationId)
        {
            var result = await _calificationService.DeleteAsync(calificationId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Calification, CalificationResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
