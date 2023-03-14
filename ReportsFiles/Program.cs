using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SautinSoft.PdfVision;
using PdfSharp.Pdf.IO;
using IronPdf;

namespace ReportsFiles
{
    class Program
    {

        public static void ConvertHtmlFileToPdfFile()
        {
            //string directoryPath = @"D:\Reports";
            //string[] reportFiles = Directory.GetFiles(directoryPath, "*.html");

            string inpFile = Path.GetFullPath(@"D:\Reports\ADSI_Jean\ADSI_AllHtmlReport\RestoreSessionTestExtentReport_at_9_58_26.html");
            string outFile = new FileInfo(@"D:\Reports\ADSI_Jean\htmlMerged\RestoreSessionTestExtentReport_at_9_58_26.pdf").FullName;

            // Local chromium will be downloaded into this directory.
            // This takes time only at the first startup.
            string chromiumDirectory = new DirectoryInfo(@"D:\Reports\Local Chromium\").FullName;

            PdfVision v = new PdfVision();
            // v.Serial = "123456789";
            HtmlToPdfOptions options = new HtmlToPdfOptions()
            {
                ChromiumBaseDirectory = chromiumDirectory,
                PageSetup = new PageSetup()
                {
                    PaperType = PaperType.LedgerTabloid,
                    Orientation = Orientation.Landscape,
                    PageMargins = new PageMargins()
                    {
                        Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
                    }
                },
                PrintBackground = true,
                Scale = 1
            };

            try
            {
                v.ConvertHtmlToPdf(inpFile, outFile, options);
                // Open the result for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            ConvertHtmlFileToPdfFile();
        }
    }
}
