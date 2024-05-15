using Asp.Versioning;
using AutoMapper;
using Core.CandidateApplicationServices;
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
    public class CandidateApplicationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICandidateApplicationService _applicationService;

        public CandidateApplicationController(IMapper mapper, ICandidateApplicationService questionService)
        {
            _mapper = mapper;
            _applicationService = questionService;
        }






        [HttpPost("apply-to-a-programme")]
        public async Task<ActionResult<AddQuestionTypeDto>> ApplyToProgramme([FromBody] ApplicationDto applicationDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data supplied" });
            }
            try
            {
                var newApplication = _mapper.Map<Application>(applicationDto);

                await _applicationService.SaveApplcationAsync(newApplication);
                return Ok(new { message = $"Application Submitted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while trying to create a question Type." });
            }
        }





        [HttpGet("view-all-applicants")]
        public async Task<ActionResult<IEnumerable<ViewApplicationDto>>> ViewAllApplcants()
        {
            var allExistingApplicants = await _applicationService.GetAllApplicantsAsync();
            if (allExistingApplicants == null || !allExistingApplicants.Any())
            {
                return NotFound(new { message = "No applicants found" });
            }
            var viewApplicantDtos = _mapper.Map<IEnumerable<ViewApplicationDto>>(allExistingApplicants);

            return Ok(new { questions = viewApplicantDtos });
        }





    }
}
