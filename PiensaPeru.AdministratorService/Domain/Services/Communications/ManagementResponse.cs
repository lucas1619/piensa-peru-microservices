using PiensaPeru.AdministratorService.Domain.Models;

namespace PiensaPeru.AdministratorService.Domain.Services.Communications
{
    public class ManagementResponse : BaseResponse<Management>
    {
        public ManagementResponse(Management resource) : base(resource)
        {
        }

        public ManagementResponse(string message) : base(message)
        {
        }
    }
}
