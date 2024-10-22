using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection.Metadata;

namespace QuizApp.Areas.Admin.Controllers
{
    public class Report : Controller
    {
        public IActionResult GeneratePdfReport()
        {
            return View();
        }
        // Create a PDF document
        MemoryStream stream = new MemoryStream();
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
        PdfWriter.GetInstance(pdfDoc, Stream);
        pdfDoc.Open();
             // Add content to the PDF
        pdfDoc.Add(new Paragraph("Student Report"));
        pdfDoc.Add(new Paragraph(" "));
        PdfPTable table = new PdfPTable(3);
        table.AddCell("ID");
        table.AddCell("Name");
        table.AddCell("Marks");
    }
}
