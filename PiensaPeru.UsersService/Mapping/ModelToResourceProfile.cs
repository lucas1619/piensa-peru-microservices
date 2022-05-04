using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Resources;

namespace PiensaPeru.UsersService.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Plan, PlanResource>();
            CreateMap<User, UserResource>();
            CreateMap<Calification, CalificationResource>();
        }
    }
}
