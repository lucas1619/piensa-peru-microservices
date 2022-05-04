using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Services;
using PiensaPeru.AdministratorService.Extensions;
using PiensaPeru.AdministratorService.Resources;

namespace PiensaPeru.AdministratorService.Controllers
{
    [Route("api/administrators/{administratorId}/[controller]")]
    [ApiController]
    public class AdministratorManagementsController : ControllerBase
    {
        private readonly IManagementService _managementService;
        private readonly IMapper _mapper;

        public AdministratorManagementsController(IManagementService managementService, IMapper mapper)
        {
            _managementService = managementService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ManagementResource>), 200)]
        //public async Task<IEnumerable<ManagementResource>> GetAllAsync()
        //{
        //    var managements = await _managementService.ListAsync();
        //    var resources = _mapper
        //        .Map<IEnumerable<Management>, IEnumerable<ManagementResource>>(managements);
        //    return resources;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ManagementResource>), 200)]
        public async Task<IEnumerable<ManagementResource>> GetAllByAdministratorIdAsync(int administratorId)
        {
            var managements = await _managementService.ListByAdministratorIdAsync(administratorId);
            var resources = _mapper
                .Map<IEnumerable<Management>, IEnumerable<ManagementResource>>(managements);
            return resources;
        }

        [HttpGet("{managementId}")]
        [ProducesResponseType(typeof(ManagementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int managementId)
        {
            var result = await _managementService.GetByIdAsync(managementId);
            if (!result.Success)
                return BadRequest(result.Message);
            var managementResource = _mapper.Map<Management, ManagementResource>(result.Resource);
            return Ok(managementResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ManagementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int administratorId, int contentId, [FromBody] SaveManagementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var management = _mapper.Map<SaveManagementResource, Management>(resource);
            var result = await _managementService.SaveAsync(administratorId, contentId, management);

            if (!result.Success)
                return BadRequest(result.Message);

            var managementResource = _mapper.Map<Management, ManagementResource>(result.Resource);
            return Ok(managementResource);
        }

        [HttpPut("{managementId}")]
        [ProducesResponseType(typeof(ManagementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int managementId, [FromBody] SaveManagementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var management = _mapper.Map<SaveManagementResource, Management>(resource);
            var result = await _managementService.UpdateAsync(managementId, management);

            if (!result.Success)
                return BadRequest(result.Message);

            var managementResource = _mapper.Map<Management, ManagementResource>(result.Resource);
            return Ok(managementResource);
        }

        [HttpDelete("{managementId}")]
        [ProducesResponseType(typeof(ManagementResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int managementId)
        {
            var result = await _managementService.DeleteAsync(managementId);

            if (!result.Success)
                return BadRequest(result.Message);

            var personResource = _mapper.Map<Management, ManagementResource>(result.Resource);
            return Ok(personResource);
        }
    }
}
