using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.tool.xml;
using System;

namespace ReportsFiles
{
    class MyTests
    {
        public static void ConvertHtmlToPdf(string htmlFilePath, string pdfFilePath)
        {
            // Create a new PDF document
            Document document = new Document();

            try
            {
                // Create a writer to write the PDF document to a file
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));

                // Open the document
                document.Open();

                // Create a new HTML parser
                iTextSharp.tool.xml.parser.XMLParser parser = new iTextSharp.tool.xml.parser.XMLParser();

                // Create a new memory stream to hold the HTML file content
                MemoryStream htmlStream = new MemoryStream(File.ReadAllBytes(htmlFilePath));

                // Parse the HTML file and add it to the document
                //parser.Parse(htmlStream, new iTextSharp.tool.xml.XMLWorker(document));

                // Close the memory stream
                htmlStream.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                throw ex;
            }
            finally
            {
                // Close the document
                document.Close();
            }
        }

        public static void GeneratePDF(string htmlFilePath, string pdfFilePath)
        {
            // Create a new document with PDF settings
            using (Document document = new Document(PageSize.LETTER))
            {
                // Create a writer to generate the PDF file
                using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create)))
                {
                    // Open the document for writing
                    document.Open();

                    // Read the HTML file into a string
                    string html = File.ReadAllText(htmlFilePath);

                    // Parse the HTML string and add it to the document
                    using (StringReader sr = new StringReader(html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                    }

                    // Close the document
                    document.Close();
                }
            }
        }
            //GeneratePDF("test_results.html", "test_results.pdf");
            //// create a new PDF document
            //PdfDocument doc = new PdfDocument();

            //// create a new PDF page
            //PdfPage page = doc.AddPage();

            //// create a PDF converter
            //HtmlToPdf converter = new HtmlToPdf();

            //// set converter options
            //converter.Options.PdfPageSize = PdfPageSize.A4;
            //converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

            //// convert HTML file to PDF
            //PdfDocument pdf = converter.ConvertUrl("path/to/your/file.html");

            //// save PDF document
            //pdf.Save("path/to/your/file.pdf");

            //// close PDF document
            //pdf.Close();
    }
}

