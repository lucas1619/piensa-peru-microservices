using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Persistence.Repositories;
using PiensaPeru.UsersService.Domain.Services.Communications;
using PiensaPeru.UsersService.Domain.Services;

namespace PiensaPeru.UsersService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                //user.PersonId = personId;
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Subscribed = user.Subscribed;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingPerson = await _userRepository.FindById(id);

            if (existingPerson == null)
                return new UserResponse("Person not found");

            try
            {
                _userRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
