using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Report;
using QuizApp.Repository.IRepository;
using QuizApp.Utility;


namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult pdf()
        {
           QuestionReport questionReport = new QuestionReport();
            List<Question> obj = _unitOfWork.Question.GetAll().ToList();
            byte[] abytes = questionReport.PrepareReport(obj);
            return File(abytes, "application/pdf");
        }

    }
}
