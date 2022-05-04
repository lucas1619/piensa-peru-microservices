using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Resources;

namespace PiensaPeru.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Content, ContentResource>();
            CreateMap<Administrator, AdministratorResource>();
            CreateMap<Management, ManagementResource>();
        }
    }
}
