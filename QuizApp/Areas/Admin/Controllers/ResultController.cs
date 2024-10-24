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
            
            IQueryable<Submission> PassFail = _db.Submission;
            List<Submission> pass = PassFail.Where(n => n.Result == "Pass").ToList();
            List<Submission> fail = PassFail.Where(n => n.Result == "Fail").ToList();
            ViewBag.PassCount = pass.Count();
            ViewBag.FailCount = fail.Count();



            return View();
        }
        public IActionResult AllResult() {
            List<Submission> ObjQuizList = _db.Submission.ToList();
            //string marks = ObjQuizList.Score;
            //bool flag = ObjQuizList.Score
            return View(ObjQuizList);

        }

    }
}
