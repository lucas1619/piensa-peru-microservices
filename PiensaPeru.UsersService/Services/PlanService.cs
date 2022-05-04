using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Persistence.Repositories;
using PiensaPeru.UsersService.Domain.Services;
using PiensaPeru.UsersService.Domain.Services.Communications;

namespace PiensaPeru.UsersService.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork)
        {
            _planRepository = planRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PlanResponse> GetByIdAsync(int id)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan not found");
            return new PlanResponse(existingPlan);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }

        public async Task<PlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                //plan.PersonId = personId;
                await _planRepository.AddAsync(plan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(plan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while saving the plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan not found");

            existingPlan.Name = plan.Name;
            existingPlan.Description = plan.Description;
            existingPlan.Price = plan.Price;

            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while updating the plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> DeleteAsync(int id)
        {
            var existingPerson = await _planRepository.FindById(id);

            if (existingPerson == null)
                return new PlanResponse("Person not found");

            try
            {
                _planRepository.Remove(existingPerson);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPerson);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while deleting the person: {ex.Message}");
            }
        }
    }
}
