

using Microsoft.AspNetCore.Mvc;
using ElearningQuizSystem.Api.Services;
using System.Threading.Tasks;
using Quiz.Server.DTOs;

namespace Quiz.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;

        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost("create")]
        public IActionResult CreateQuiz(CreateQuizDTO createQuizDto)
        {
            var result = _quizService.CreateQuiz(createQuizDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

    }
}
