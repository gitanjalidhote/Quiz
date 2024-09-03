

using Microsoft.AspNetCore.Mvc;
using ElearningQuizSystem.Api.Services;
using ElearningQuizSystem.Api.DTOs;
using System.Threading.Tasks;

namespace ElearningQuizSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizResultController : ControllerBase
    {
        private readonly QuizResultService _quizResultService;

        public QuizResultController(QuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz(SubmitQuizDTO submitQuizDto)
        {
            var result = await _quizResultService.SubmitQuizAsync(submitQuizDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizResult(int id)
        {
            var quizResult = await _quizResultService.GetQuizResultByIdAsync(id);
            if (quizResult == null)
            {
                return NotFound();
            }
            return Ok(quizResult);
        }

        // Other endpoints related to quiz results
    }
}
