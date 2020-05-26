using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorePracticeWebApp.Models;
using IronPdf;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Xceed;

namespace CorePracticeWebApp
{
    public static class PrintServices
    {
        public static PdfDocument RenderPdf(int id)
        {
            Members member = MemberServices.GetMember(id);
            if(member == null)
            {
                throw new FileNotFoundException();
            }

            var text = File.ReadAllText("./Document/Template.html");
            var dateString = member.DateofBap == null ? "" : DateTime.Parse(member.DateofBap.ToString()).ToString("MMMM dd, yyyy");
            text = text.Replace("%%MEMBERNAME%%", member.FirstName + " " + member.LastName).Replace("%%DATEOFBAP%%", dateString);
            File.WriteAllText($"./Document/Member-{id}.html", text);

            //using (var document = DocX.Load("./Document/Template.docx"))
            //{
            //    document.ReplaceText("%%MEMBERNAME%%", member.FirstName, false);
            //    document.ReplaceText("%%DATEOFBAP%%", member.DateofBap.ToString(), false);
            //    //DocX.ConvertToPdf();
            //    document.SaveAs("./Document/Member.docx");
            //}

            // Create a PDF from any existing web page
            var Renderer = new IronPdf.HtmlToPdf();
            Renderer.PrintOptions.PaperOrientation = PdfPrintOptions.PdfPaperOrientation.Landscape;
            //var PDF = Renderer.RenderUrlAsPdf("https://en.wikipedia.org/wiki/Portable_Document_Format");
            var PDF = Renderer.RenderUrlAsPdf($"./Document/Member-{id}.html");
            File.Delete($"./Document/Member-{id}.html");
            // PDF.RotatePage(0, 90);
            //PDF.SaveAs("./output/output_"+id+".pdf");
            // This neat trick opens our PDF file so we can see the result
            //System.Diagnostics.Process.Start("wikipedia.pdf");
            return PDF;
        }

    }
}
