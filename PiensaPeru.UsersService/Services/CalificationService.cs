using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Persistence.Repositories;
using PiensaPeru.UsersService.Domain.Services;
using PiensaPeru.UsersService.Domain.Services.Communications;

namespace PiensaPeru.UsersService.Services
{
    public class CalificationService : ICalificationService
    {
        private readonly ICalificationRepository _calificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CalificationService(ICalificationRepository calificationRepository, IUnitOfWork unitOfWork)
        {
            _calificationRepository = calificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CalificationResponse> GetByIdAsync(int id)
        {
            var existingCalification = await _calificationRepository.FindById(id);

            if (existingCalification == null)
                return new CalificationResponse("Calification not found");
            return new CalificationResponse(existingCalification);
        }

        public async Task<IEnumerable<Calification>> ListAsync()
        {
            return await _calificationRepository.ListAsync();
        }

        public async Task<CalificationResponse> SaveAsync(int userId, Calification calification)
        {
            try
            {
                calification.UserId = userId;
                await _calificationRepository.AddAsync(calification);
                await _unitOfWork.CompleteAsync();

                return new CalificationResponse(calification);
            }
            catch (Exception ex)
            {
                return new CalificationResponse($"An error ocurred while saving the calification: {ex.Message}");
            }
        }

        public async Task<CalificationResponse> UpdateAsync(int id, Calification calification)
        {
            var existingCalification = await _calificationRepository.FindById(id);

            if (existingCalification == null)
                return new CalificationResponse("Calification not found");

            existingCalification.Score = calification.Score;

            try
            {
                _calificationRepository.Update(existingCalification);
                await _unitOfWork.CompleteAsync();

                return new CalificationResponse(existingCalification);
            }
            catch (Exception ex)
            {
                return new CalificationResponse($"An error ocurred while updating the calification: {ex.Message}");
            }
        }

        public async Task<CalificationResponse> DeleteAsync(int id)
        {
            var existingPerson = await _calificationRepository.FindById(id);

            if (existingPerson == null)
                return new CalificationResponse("Person not found");

            try
            {
                _calificationRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new CalificationResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new CalificationResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Calification>> ListByUserIdAsync(int userId)
        {
            return await _calificationRepository.ListByUserIdAsync(userId);
        }
    }
}
