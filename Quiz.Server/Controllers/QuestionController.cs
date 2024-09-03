

using Microsoft.AspNetCore.Mvc;
using ElearningQuizSystem.Api.Services;
using ElearningQuizSystem.Api.DTOs;
using System.Threading.Tasks;

namespace ElearningQuizSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddQuestion(CreateQuestionDTO createQuestionDto)
        {
            var result = await _questionService.AddQuestionAsync(createQuestionDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditQuestion(int id, CreateQuestionDTO createQuestionDto)
        {
            var result = await _questionService.EditQuestionAsync(id, createQuestionDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _questionService.DeleteQuestionAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

       
    }
}
