using Microsoft.AspNetCore.Identity;
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
        //private readonly UserManager<ApplicationUser> _userManager;
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
        public   IActionResult SubmitTest(List<QuizAppResponse> Responses , int QuizId)
        {
            string topic = _db.Quiz.Where(u => u.quiz_id == QuizId).First().Topic;
            int correctAnswers = 0;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            //var user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            //string userName = user?.Name;





            // Evaluate the test
            foreach (var QuizAppResponse in Responses)
            {
                var question = _db.Question.Find(QuizAppResponse.QuestionId);
                if (question != null && QuizAppResponse.SelectedAnswer == question.CorrectOption)
                {
                    correctAnswers++;
                }
            }

            // Calculate score as a percentage
            int totalQuestions = Responses.Count;
            string score = $"{(correctAnswers * 100) / totalQuestions}%";
            string proxy = score.Substring(0, score.Length - 2 + 1);
            int marks = int.Parse(proxy);
            // Save submission to the database
            var submission = new Submission
            {
                UserId = userId , // Gets the logged-in user's ID
 // Hardcoded for now. Replace with actual logged-in user ID.
                Result = marks > 40 ? "Pass" : "Fail" ,
                UserName= userName ,
                Topic = topic ,
                Quiz_Id = QuizId, 
                Score = score.ToString(),
                SubmittedAt = DateTime.UtcNow
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
