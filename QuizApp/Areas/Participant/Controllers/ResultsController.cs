using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using QuizApp.Data_Server;
using QuizApp.Models;
using Microsoft.AspNetCore.Authorization;
using QuizApp.Utility;

namespace QuizApp.Areas.Participant.Controllers
{
    [Area("Participant")]
    [Authorize(Roles = SD.Role_Participant)]
    public class ResultsController : Controller
    {
        
        private readonly AppDbContext _db;

        public ResultsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult MyResults()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var submissions = _db.Submission
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SubmittedAt)
                .ToList();

            return View(submissions);
        }
    }
}

