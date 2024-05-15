

using Data.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace Core.CandidateApplicationServices
{
    public class CandidateApplicationService : ICandidateApplicationService
    {
        private readonly Container _applicantContainer;
        private readonly IConfiguration _configuration;

        public CandidateApplicationService(CosmosClient cosmosClient, IConfiguration configuration)
        { 
            _configuration = configuration;
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var applicantContainerName = "Applicants";
            _applicantContainer = cosmosClient.GetContainer(databaseName, applicantContainerName);
        }



        public async Task<Application> SaveApplcationAsync(Application application)
        {
            var response = await _applicantContainer.CreateItemAsync(application);
            return response.Resource;
        }


        public async Task<List<Application>> GetAllApplicantsAsync()
        {
            var query = _applicantContainer.GetItemLinqQueryable<Application>()
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.ToList();
        }



    }
}
