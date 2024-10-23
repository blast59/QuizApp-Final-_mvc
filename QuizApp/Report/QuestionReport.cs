using iTextSharp.text;

using iTextSharp.text.pdf;

using QuizApp.Models;

using System.Drawing.Text;

namespace QuizApp.Report

{

    public class QuestionReport

    {

        #region
        int _totalColumn = 7;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdftable = new PdfPTable(7);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Question> _question = new List<Question>();
        #endregion
        public byte[] PrepareReport(List<Question> question)
        {
            _question = question;
            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdftable.WidthPercentage = 100;
            _pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdftable.SetWidths(new float[] { 10f, 40f, 10f , 10f , 10f , 10f , 10f });
           this.ReportHeader();
            this.ReportBody();
            _pdftable.HeaderRows = 2;
            _document.Add(_pdftable);
            _document.Close();
            return _memoryStream.ToArray();
            #endregion
        }
        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Arial", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("All Question", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdftable.AddCell(_pdfPCell);
           _pdftable.CompleteRow();
        }
        private void ReportBody()
        {
            #region Table header
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serial Number", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdftable.AddCell(_pdfPCell);
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Text", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
           _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdftable.AddCell(_pdfPCell);
           _fontStyle = FontFactory.GetFont("Arial", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Option A", _fontStyle));

            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdftable.AddCell(_pdfPCell);



            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Option B", _fontStyle));

            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdftable.AddCell(_pdfPCell);



            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Option C", _fontStyle));

            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdftable.AddCell(_pdfPCell);



            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Opiton D", _fontStyle));

            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdftable.AddCell(_pdfPCell);



            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Correct Answer", _fontStyle));

            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            _pdftable.AddCell(_pdfPCell);



            _pdftable.CompleteRow();

            #endregion

            #region Table Body

            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);

            int serialNumber = 1;

            foreach (Question q in _question)

            {

                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));

                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfPCell.BackgroundColor = BaseColor.WHITE;

                _pdftable.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase(q.QuestionText, _fontStyle));

                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfPCell.BackgroundColor = BaseColor.WHITE;

                _pdftable.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase(q.OptionA, _fontStyle));

                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfPCell.BackgroundColor = BaseColor.WHITE;

                _pdftable.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase(q.OptionB, _fontStyle));

                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;

                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfPCell.BackgroundColor = BaseColor.WHITE;

                _pdftable.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase(q.OptionC, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdftable.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(q.OptionD, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdftable.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(q.CorrectOption, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdftable.AddCell(_pdfPCell);
                _pdftable.CompleteRow();

            }



            #endregion

        }



    }

}