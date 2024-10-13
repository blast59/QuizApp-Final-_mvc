using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data_Server;
using QuizApp.Models;

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
            // Fetch all questions for a specific quiz (assuming QuizId = 1)
            var questions = _db.Question.Where(q => q.QuizId == id).ToList();
            return View(questions);
        }
        [HttpPost]
        public IActionResult SubmitTest(List<Question> responses)
        {
            // Handle submission logic, calculate score, etc.
            //int score = responses.Count(r => r.SelectedOption == r.CorrectOption);
            //ViewBag.Score = score;

            return View("Result");
        }

        //public IActionResult Create(int? Id)
        //{
        //    ViewBag.QuizId = Id;
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Question _obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Question.Add(_obj);
        //        _unitOfWork.Save();
        //        TempData["Success"] = "Topic added successfully";
        //        return RedirectToAction("Index", new { id = _obj.QuizId });
        //    }
        //    return View();
        //}

        //public IActionResult Edit(int? id)
        //{
        //    ViewBag.QuestionId = id;
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    //Quiz Editquiz = _db.Quiz.Find(id);      //finds the record with the help of only primary key
        //    Question Editquiz = _unitOfWork.Question.Get(u => u.QuestionId == id);
        //    //Quiz Editquiz2 = _db.Quiz.Where(u => u.quiz_id == id).FirstOrDefault();
        //    if (Editquiz == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Editquiz);
        //}
        //[HttpPost]
        //public IActionResult Edit(Question _obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        //_db.Quiz.Update(_obj);
        //        //_db.SaveChanges();
        //        _unitOfWork.Question.Update(_obj);
        //        _unitOfWork.Save();

        //        TempData["Success"] = "Topic changed successfully";
        //        return RedirectToAction("Index", new { id = _obj.QuizId });
        //    }
        //    return View();
        //}
        //public IActionResult Delete(int? id)
        //{
        //    ViewBag.QuestionId = id;
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Question? Editquiz = _unitOfWork.Question.Get(u => u.QuestionId == id);//finds the record with the help of only primary key
        //    if (Editquiz == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Editquiz);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    Question? obj = _unitOfWork.Question.Get(u => u.QuestionId == id);
        //    if (obj == null)
        //        return NotFound();
        //    _unitOfWork.Question.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["Success"] = "Topic deleted successfully";
        //    return RedirectToAction("Index" , new { id = obj.QuizId });
        //}
    }
}
