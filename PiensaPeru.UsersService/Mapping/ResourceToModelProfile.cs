using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Resources;

namespace PiensaPeru.UsersService.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();
            CreateMap<SavePlanResource, Plan>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCalificationResource, Calification>();
        }
    }
}
