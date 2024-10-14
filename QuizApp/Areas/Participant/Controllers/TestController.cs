using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data_Server;
using QuizApp.Models;
using System.Security.Claims;
using QuizAppResponse = QuizApp.Models.Response;

namespace QuizApp.Areas.Participant.Controllers
{
    [Area("Participant")]
    public class TestController : Controller
    {
        private readonly AppDbContext _db;
        public TestController(AppDbContext db)
        {
            _db = db;
        }
        //private readonly IUnitOfWork _unitOfWork;
        //public TestController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        //public IActionResult AllIndex()
        //{
        //    List<Question> ObjQuizList = _unitOfWork.Question.GetAll().ToList();
        //    return View(ObjQuizList);
        //}

        public IActionResult Index()
        {
            List<Quiz> ObjQuizList = _db.Quiz.ToList();
            //  return View(ObjQuizList);
            return View(ObjQuizList);
        }
        public IActionResult TakeTest(int? id)
        {
            //var questions = _db.Question.Where(q => q.QuizId == id).ToList();
            // Fetch all questions for a specific quiz (assuming QuizId = 1)
            var questions = _db.Question.Where(q => q.QuizId == id).ToList();
            return View(questions);
        }
        [HttpPost]
        public IActionResult SubmitTest(List<QuizAppResponse> Responses , int QuizId)
        {
            int correctAnswers = 0;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Evaluate the test
            foreach (var QuizAppResponse in Responses)
            {
                var question = _db.Question.Find(QuizAppResponse.QuestionId);
                if (question != null && QuizAppResponse.SelectedOption == question.CorrectOption)
                {
                    correctAnswers++;
                }
            }

            // Calculate score as a percentage
            int totalQuestions = Responses.Count;
            string score = $"{(correctAnswers * 100) / totalQuestions}%";

            // Save submission to the database
            var submission = new Submission
            {
                UserId = int.Parse(userId) , // Gets the logged-in user's ID
 // Hardcoded for now. Replace with actual logged-in user ID.
                Quiz_Id = 1, // Replace with the relevant quiz ID.
                Score = score.ToString()
            };

            _db.Submission.Add(submission);
            _db.SaveChanges();

            // Redirect to a confirmation or result page
            return RedirectToAction("TestResult", new { score = score });
        }

        public IActionResult TestResult(string score)
        {
            ViewBag.Score = score;
            return View();
        }
    }
}
