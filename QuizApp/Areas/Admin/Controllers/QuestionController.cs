using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.Repository.IRepository;
using System.Runtime.CompilerServices;
namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        //private readonly AppDbContext _db;
        //public QuizController(AppDbContext db)
        //{
        //    _db = db;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult AllIndex()
        {
            List<Question> ObjQuizList = _unitOfWork.Question.GetAll().ToList();
            return View(ObjQuizList);
        }

        public IActionResult Index(int? id)
        {
            if(id == 0 || id== null)
                  return NotFound();
            if(id == -1)
            {
                List<Question> ObjQuizList1 = _unitOfWork.Question.GetAll().ToList();
            }
            List<Question> ObjQuizList = _unitOfWork.Question.GetAll().Where(u => u.QuizId == id).ToList();
            ViewBag.QuizId = id;
            var quiz = _unitOfWork.Quiz.Get(q => q.quiz_id == id);

            // Store the quiz topic in ViewBag
            ViewBag.QuizTopic = quiz.Topic;
            return View(ObjQuizList);
        }
        public IActionResult Create(int? Id)
        {
            ViewBag.QuizId = Id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question _obj)
        {         
            if (ModelState.IsValid)
            {
                _unitOfWork.Question.Add(_obj);
                _unitOfWork.Save();
                TempData["Success"] = "Topic added successfully";
                return RedirectToAction("Index", new { id = _obj.QuizId });
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.QuestionId = id;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Quiz Editquiz = _db.Quiz.Find(id);      //finds the record with the help of only primary key
            Question Editquiz = _unitOfWork.Question.Get(u => u.QuestionId == id);
            //Quiz Editquiz2 = _db.Quiz.Where(u => u.quiz_id == id).FirstOrDefault();
            if (Editquiz == null)
            {
                return NotFound();
            }
            return View(Editquiz);
        }
        [HttpPost]
        public IActionResult Edit(Question _obj)
        {

            if (ModelState.IsValid)
            {
                //_db.Quiz.Update(_obj);
                //_db.SaveChanges();
                _unitOfWork.Question.Update(_obj);
                _unitOfWork.Save();

                TempData["Success"] = "Topic changed successfully";
                return RedirectToAction("Index", new { id = _obj.QuizId });
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            ViewBag.QuestionId = id;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Question? Editquiz = _unitOfWork.Question.Get(u => u.QuestionId == id);//finds the record with the help of only primary key
            if (Editquiz == null)
            {
                return NotFound();
            }
            return View(Editquiz);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Question? obj = _unitOfWork.Question.Get(u => u.QuestionId == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Question.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Topic deleted successfully";
            return RedirectToAction("Index" , new { id = obj.QuizId });
        }
    }
}
