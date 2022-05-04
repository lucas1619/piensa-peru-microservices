using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Persistence.Repositories;
using PiensaPeru.AdministratorService.Domain.Services;
using PiensaPeru.AdministratorService.Domain.Services.Communications;

namespace PiensaPeru.AdministratorService.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdministratorService(IAdministratorRepository administratorRepository, IUnitOfWork unitOfWork)
        {
            _administratorRepository = administratorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AdministratorResponse> GetByIdAsync(int id)
        {
            var existingAdministrator = await _administratorRepository.FindById(id);

            if (existingAdministrator == null)
                return new AdministratorResponse("Administrator not found");
            return new AdministratorResponse(existingAdministrator);
        }

        public async Task<IEnumerable<Administrator>> ListAsync()
        {
            return await _administratorRepository.ListAsync();
        }

        public async Task<AdministratorResponse> SaveAsync(Administrator administrator)
        {
            try
            {
                //administrator.PersonId = personId;
                await _administratorRepository.AddAsync(administrator);
                await _unitOfWork.CompleteAsync();

                return new AdministratorResponse(administrator);
            }
            catch (Exception ex)
            {
                return new AdministratorResponse($"An error ocurred while saving the administrator: {ex.Message}");
            }
        }

        public async Task<AdministratorResponse> UpdateAsync(int id, Administrator administrator)
        {
            var existingAdministrator = await _administratorRepository.FindById(id);

            if (existingAdministrator == null)
                return new AdministratorResponse("Administrator not found");

            existingAdministrator.Email = administrator.Email;
            existingAdministrator.Password = administrator.Password;
            existingAdministrator.FirstName = administrator.FirstName;
            existingAdministrator.LastName = administrator.LastName;

            try
            {
                _administratorRepository.Update(existingAdministrator);
                await _unitOfWork.CompleteAsync();

                return new AdministratorResponse(existingAdministrator);
            }
            catch (Exception ex)
            {
                return new AdministratorResponse($"An error ocurred while updating the administrator: {ex.Message}");
            }
        }

        public async Task<AdministratorResponse> DeleteAsync(int id)
        {
            var existingPerson = await _administratorRepository.FindById(id);

            if (existingPerson == null)
                return new AdministratorResponse("Person not found");

            try
            {
                _administratorRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new AdministratorResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new AdministratorResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
