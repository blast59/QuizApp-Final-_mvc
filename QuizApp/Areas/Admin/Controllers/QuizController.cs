using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Repository;
using QuizApp.Repository.IRepository;
using QuizApp.Utility;
using System.Runtime.CompilerServices;
namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class QuizController : Controller
    {
        //private readonly AppDbContext _db;
        //public QuizController(AppDbContext db)
        //{
        //    _db = db;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Quiz> ObjQuizList = _unitOfWork.Quiz.GetAll().OrderBy(u => u.quiz_id).ToList();
            return View(ObjQuizList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Create([FromBody] Quiz _obj)
        {
            if (int.TryParse(_obj.Topic, out int result))
            {
                ModelState.AddModelError("", "Topic cannot be an numeric value");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Quiz.Add(_obj);
                _unitOfWork.Save();
                TempData["Success"] = "Topic added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }   
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Quiz Editquiz = _db.Quiz.Find(id);      //finds the record with the help of only primary key
            Quiz Editquiz = _unitOfWork.Quiz.Get(u => u.quiz_id == id);
            //Quiz Editquiz2 = _db.Quiz.Where(u => u.quiz_id == id).FirstOrDefault();
            if (Editquiz == null)
            {
                return NotFound();
            }
            return View(Editquiz);
        }
        [HttpPost]
        public IActionResult Edit(Quiz _obj)
        {
            if (ModelState.IsValid)
            {
                //_db.Quiz.Update(_obj);
                //_db.SaveChanges();
                _unitOfWork.Quiz.Update(_obj);
                _unitOfWork.Save();

                TempData["Success"] = "Topic changed successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Quiz? Editquiz = _unitOfWork.Quiz.Get(u => u.quiz_id == id);//finds the record with the help of only primary key
            if (Editquiz == null)
            {
                return NotFound();
            }
            return View(Editquiz);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Quiz? obj = _unitOfWork.Quiz.Get(u => u.quiz_id == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Quiz.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Topic deleted successfully";
            return RedirectToAction("Index");


        }
    }
}
