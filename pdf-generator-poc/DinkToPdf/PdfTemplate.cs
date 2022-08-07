using System.Text;

namespace pdf_generator_poc.DinkToPdf
{
    public static class PdfTemplate
    {
        public static string GetHTMLString(string createdBy)
        {
            var sb = new StringBuilder();

            sb.Append($@"<html>
                            <head></head>
                            <body>
                                <h1>PDF File</h1>
                                <p>This PDF was created by {createdBy}</p>
                            </body>");

            return sb.ToString();
        }
    }
}
