using PiensaPeru.AdministratorService.Domain.Models;

namespace PiensaPeru.AdministratorService.Domain.Services.Communications
{
    public class AdministratorResponse : BaseResponse<Administrator>
    {
        public AdministratorResponse(Administrator resource) : base(resource)
        {
        }

        public AdministratorResponse(string message) : base(message)
        {
        }
    }
}
