using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Resources;

namespace PiensaPeru.API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();
            CreateMap<SaveContentResource, Content>();
            CreateMap<SaveAdministratorResource, Administrator>();
            CreateMap<SaveManagementResource, Management>();
        }
    }
}
