using DinkToPdf;
using DinkToPdf.Contracts;
using pdf_generator_poc.DinkToPdf;
using pdf_generator_poc.Interfaces;

namespace pdf_generator_poc.Services
{
    public class DinkToPdfService : IPdfService<string>
    {
        private readonly IConverter _converter;
        private readonly GlobalSettings _globalSettings;
        private readonly ObjectSettings _objectSettings;

        public string OutputPath => "output/dink-to-pdf";

        public DinkToPdfService(IConverter converter) 
        {
            _converter = converter;

            _globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
            };

            _objectSettings = new ObjectSettings
            {
                PagesCount = true,
                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
        }

        public async Task<bool> CreatePdf(string content)
        {
            var guid = Guid.NewGuid();

            if (!Directory.Exists(@$"{Directory.GetCurrentDirectory()}\{OutputPath}"))
                Directory.CreateDirectory(@$"{Directory.GetCurrentDirectory()}\{OutputPath}");

            _globalSettings.Out = @$"{Directory.GetCurrentDirectory()}\{OutputPath}\Report-{guid}.pdf";
            _objectSettings.HtmlContent = PdfTemplate.GetHTMLString(content);

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = _globalSettings,
                Objects = { _objectSettings }
            };

            var bytes = _converter.Convert(pdf);

            return bytes.Any() ? true : false;
        }
    }
}
