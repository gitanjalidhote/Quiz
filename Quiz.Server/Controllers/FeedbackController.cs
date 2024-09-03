﻿


using Microsoft.AspNetCore.Mvc;
using ElearningQuizSystem.Api.Services;
using ElearningQuizSystem.Api.DTOs;
using System.Threading.Tasks;

namespace ElearningQuizSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("provide")]
        public async Task<IActionResult> ProvideFeedback(FeedbackDTO feedbackDto)
        {
            var result = await _feedbackService.ProvideFeedbackAsync(feedbackDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpGet("{quizResultId}")]
        public async Task<IActionResult> GetFeedback(int quizResultId)
        {
            var feedback = await _feedbackService.GetFeedbackByQuizResultIdAsync(quizResultId);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // Other endpoints related to feedback management
    }
}
