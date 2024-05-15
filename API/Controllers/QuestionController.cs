using Asp.Versioning;
using AutoMapper;
using Core.QuestionServices;
using Data.Dtos;
using Data.Enums;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public QuestionController(IMapper mapper, IQuestionService questionService)
        {
            _mapper = mapper;
            _questionService = questionService;
        }





        [HttpPost("add-question-type")]
        public async Task<ActionResult<AddQuestionTypeDto>> AddQuestionType([FromBody] AddQuestionTypeDto addQuestionTypeDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid Question Type supplied" });
            }        
            try
            {
                var newQuestionType = _mapper.Map<QuestionType>(addQuestionTypeDto);
                 
                await _questionService.StoreQuestionTypeAsync(newQuestionType);
                return Ok(new {message = $"{addQuestionTypeDto.Type} Question Type was successfully added"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while trying to create a question Type." });
            }
        }




        [HttpPost("add-a-question")]
        public async Task<ActionResult<AddQuestionDto>> AddQuestion([FromBody] AddQuestionDto addQuestionDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data supplied" });
            }
            try
            {
                var newQuestion = _mapper.Map<Question>(addQuestionDto);

                await _questionService.StoreQuestionsAsync(newQuestion);
                return Ok(new { message = "Question was successfully added" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while trying to create a question Type." });
            }
        }



        [HttpPut("update-a-question/{questionId}")]
        public async Task<ActionResult<UpdateQuestionDto>> UpdateQuestion(string questionId, [FromBody] UpdateQuestionDto updateQuestionDto)
        {
            var existingQuestion = await _questionService.GetQuestionByIdAsync(questionId);
            if (existingQuestion == null)
            {
                return NotFound(new { message = "question was not found" });
            }
            var updatedQuestion = _mapper.Map(updateQuestionDto, existingQuestion);

            await _questionService.EditQuestionAsync(updatedQuestion);
            return Ok(new { message = "Question has been updated successfully." });
        }




        [HttpGet("view-all-questions")]
        public async Task<ActionResult<IEnumerable<ViewQuestionDto>>> ViewAllQuestions()
        {
            var allExistingQuestions = await _questionService.GetAllQuestionsAsync();
            if (allExistingQuestions == null || !allExistingQuestions.Any())
            {
                return NotFound(new { message = "No questions found" });
            }

            var viewQuestionDtos = allExistingQuestions.Select(q => new ViewQuestionDto
            {
                Id = q.Id,
                TheQuestion = q.TheQuestion,
                QuestionType = q.QuestionType,
                ProgramId = q.ProgramId
            }).ToList();

            return Ok(new { questions = viewQuestionDtos });
        }



        [HttpGet("view-question-by-questionType")]
        public async Task<ActionResult<IEnumerable<ViewQuestionDto>>> ViewQuestionsByQuestionType(QuestionTypeEnum questionType)
        {
            var allQuestions = await _questionService.GetAllQuestionsByQuestionTypeAsync(questionType);
            if (allQuestions == null || !allQuestions.Any())
            {
                return NotFound(new { message = $"No {questionType} questions found" });
            }

            var viewQuestionDtos = allQuestions.Select(q => new ViewQuestionDto
            {
                Id = q.Id,
                TheQuestion = q.TheQuestion,
                QuestionType = q.QuestionType,
                ProgramId = q.ProgramId
            }).ToList();

            return Ok(new { questions = viewQuestionDtos });
        }
    }
}
