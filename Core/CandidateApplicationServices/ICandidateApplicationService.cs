
using Data.Models;

namespace Core.CandidateApplicationServices
{
    public interface ICandidateApplicationService
    {
        Task<Application> SaveApplcationAsync(Application application);
        Task<List<Application>> GetAllApplicantsAsync();
    }
}
