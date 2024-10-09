using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
using System.Runtime.CompilerServices;
using System.Security;
namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly AppDbContext _db;
        public QuestionController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Create(int? id)
        {
            TempData["quizId"] = id;
           // Quiz obj = _db.Quiz.Find(id);
            return View();
        }
        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                // Add the question to the database
                _db.Question.Add(question);
                _db.SaveChanges();

                return RedirectToAction("Index", "Quiz"); // Redirect to the quiz list or another page
            }

            return View(question);
        }


    }
}
