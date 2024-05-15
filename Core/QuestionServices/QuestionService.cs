using Data.Enums;
using Data.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
namespace Core.QuestionServices
{
    public class QuestionService : IQuestionService
    {
        private readonly Container _questionContainer;
        private readonly Container _questionTypesContainer;
        private readonly IConfiguration _configuration;

        public QuestionService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _configuration = configuration;
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var questionContainerName = "Questions";
            var questionTypesContainerName = "QuestionTypes";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
            _questionTypesContainer = cosmosClient.GetContainer(databaseName, questionTypesContainerName);
        }



        public async Task<QuestionType> StoreQuestionTypeAsync(QuestionType questionType)
        { 
            var response = await _questionTypesContainer.CreateItemAsync(questionType);
            return response.Resource;
        }



        public async Task<Question> StoreQuestionsAsync(Question question)
        {
            var response = await _questionContainer.CreateItemAsync(question);
            return response.Resource;
        }


        public async Task<Question> EditQuestionAsync(Question question) 
        {
            var response = await _questionContainer.ReplaceItemAsync(question, question.Id);
            return response.Resource;
        }


        public async Task<Question> GetQuestionByIdAsync(string questionId)
        { 
            var query =  _questionContainer.GetItemLinqQueryable<Question>()
                .Where(u => u.Id == questionId)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }


        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            var query = _questionContainer.GetItemLinqQueryable<Question>()
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.ToList();
        }

        public async Task<List<Question>> GetAllQuestionsByQuestionTypeAsync(QuestionTypeEnum questionType)
        {
            var query = _questionContainer.GetItemLinqQueryable<Question>()
                .Where(q => q.QuestionType == questionType)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.ToList();
        }

    }
}
