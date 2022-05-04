using PiensaPeru.UsersService.Domain.Models;

namespace PiensaPeru.UsersService.Domain.Services.Communications
{
    public class CalificationResponse : BaseResponse<Calification>
    {
        public CalificationResponse(Calification resource) : base(resource)
        {
        }

        public CalificationResponse(string message) : base(message)
        {
        }
    }
}
