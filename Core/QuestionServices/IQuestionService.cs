using Data.Enums;
using Data.Models;

namespace Core.QuestionServices
{
    public interface IQuestionService
    {
        Task<QuestionType> StoreQuestionTypeAsync(QuestionType questionType);
        Task<Question> StoreQuestionsAsync(Question question);
        Task<Question> EditQuestionAsync(Question question);
        Task<Question> GetQuestionByIdAsync(string questionId);
        Task<List<Question>> GetAllQuestionsAsync();
        Task<List<Question>> GetAllQuestionsByQuestionTypeAsync(QuestionTypeEnum questionType);
    }
}
