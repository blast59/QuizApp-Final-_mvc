using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Utility;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ResultController : Controller
    {
        
        private readonly AppDbContext _db;
        public ResultController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllResult() {
            List<Submission> ObjQuizList = _db.Submission.ToList();
            return View(ObjQuizList);

        }
    }
}
