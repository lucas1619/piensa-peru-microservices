using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Services;
using PiensaPeru.AdministratorService.Extensions;
using PiensaPeru.AdministratorService.Resources;

namespace PiensaPeru.AdministratorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;
        private readonly IMapper _mapper;

        public AdministratorsController(IAdministratorService administratorService, IMapper mapper)
        {
            _administratorService = administratorService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AdministratorResource>), 200)]
        public async Task<IEnumerable<AdministratorResource>> GetAllAsync()
        {
            try
            {
                var administrators = await _administratorService.ListAsync();
                var resources = _mapper
                    .Map<IEnumerable<Administrator>, IEnumerable<AdministratorResource>>(administrators);
                return resources;
            } catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdministratorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _administratorService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var administratorResource = _mapper.Map<Administrator, AdministratorResource>(result.Resource);
            return Ok(administratorResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AdministratorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAdministratorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var administrator = _mapper.Map<SaveAdministratorResource, Administrator>(resource);
            var result = await _administratorService.SaveAsync(administrator);

            if (!result.Success)
                return BadRequest(result.Message);

            var administratorResource = _mapper.Map<Administrator, AdministratorResource>(result.Resource);
            return Ok(administratorResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AdministratorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdministratorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var administrator = _mapper.Map<SaveAdministratorResource, Administrator>(resource);
            var result = await _administratorService.UpdateAsync(id, administrator);

            if (!result.Success)
                return BadRequest(result.Message);

            var administratorResource = _mapper.Map<Administrator, AdministratorResource>(result.Resource);
            return Ok(administratorResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AdministratorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _administratorService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Administrator, AdministratorResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
