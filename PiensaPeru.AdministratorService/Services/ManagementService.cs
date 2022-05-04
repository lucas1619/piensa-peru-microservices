using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Persistence.Repositories;
using PiensaPeru.AdministratorService.Domain.Services;
using PiensaPeru.AdministratorService.Domain.Services.Communications;

namespace PiensaPeru.AdministratorService.Services
{
    public class ManagementService : IManagementService
    {
        private readonly IManagementRepository _managementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ManagementService(IManagementRepository managementRepository, IUnitOfWork unitOfWork)
        {
            _managementRepository = managementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ManagementResponse> GetByIdAsync(int id)
        {
            var existingManagement = await _managementRepository.FindById(id);

            if (existingManagement == null)
                return new ManagementResponse("Management not found");
            return new ManagementResponse(existingManagement);
        }

        public async Task<IEnumerable<Management>> ListAsync()
        {
            return await _managementRepository.ListAsync();
        }

        public async Task<ManagementResponse> SaveAsync(int administratorId, int contentId, Management management)
        {
            try
            {
                management.AdministratorId = administratorId;
                management.ContentId = contentId;
                await _managementRepository.AddAsync(management);
                await _unitOfWork.CompleteAsync();

                return new ManagementResponse(management);
            }
            catch (Exception ex)
            {
                return new ManagementResponse($"An error ocurred while saving the management: {ex.Message}");
            }
        }

        public async Task<ManagementResponse> UpdateAsync(int id, Management management)
        {
            var existingManagement = await _managementRepository.FindById(id);

            if (existingManagement == null)
                return new ManagementResponse("Management not found");

            try
            {
                _managementRepository.Update(existingManagement);
                await _unitOfWork.CompleteAsync();

                return new ManagementResponse(existingManagement);
            }
            catch (Exception ex)
            {
                return new ManagementResponse($"An error ocurred while updating the management: {ex.Message}");
            }
        }

        public async Task<ManagementResponse> DeleteAsync(int id)
        {
            var existingPerson = await _managementRepository.FindById(id);

            if (existingPerson == null)
                return new ManagementResponse("Person not found");

            try
            {
                _managementRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new ManagementResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new ManagementResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Management>> ListByAdministratorIdAsync(int administratorId)
        {
            return await _managementRepository.ListByAdministratorIdAsync(administratorId);
        }
    }
}
