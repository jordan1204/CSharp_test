using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace iTextSharpTest
{
    class SplitPdf
    {
        private static void ExtractPages(string sourcePDFpath, string outputPDFpath, int startpage, int endpage)
        {
            PdfReader reader = null;//讀取pdf
            Document sourceDocument = null;//文件
            PdfCopy pdfCopyProvider = null;//copy pdf
            PdfImportedPage importedPage = null;//把reader裡的page import進來的頁

            reader = new PdfReader(sourcePDFpath);
            sourceDocument = new Document(reader.GetPageSizeWithRotation(startpage));
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPDFpath, System.IO.FileMode.Create));

            sourceDocument.Open();

            for (int i = startpage; i <= endpage; i++)
            {
                importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                pdfCopyProvider.AddPage(importedPage);//在output pdf裡add page
            }
            sourceDocument.Close();
            reader.Close();
        }
        static void Main(string[] args)
        {
            //var doc1 = new Document(PageSize.A4, 50, 50, 80, 50);
            ////MemoryStream ms = new MemoryStream();
            //PdfWriter writer = PdfWriter.GetInstance(doc1, new FileStream("ChunkPhraseParagraph.pdf", FileMode.Create));
            //BaseFont bfChinese = BaseFont.CreateFont(@"C:\Users\a0933\Desktop\iTextSharpTest\iTextSharpTest\fonts\kaiu.ttf",BaseFont.IDENTITY_H,BaseFont.NOT_EMBEDDED);
            //Font ChFont = new Font(bfChinese, 12);
            //doc1.Open();
            //doc1.Add(new Paragraph(10f, "Hello 大家好!", ChFont));
            //doc1.Close();
            //writer.Close();
            ExtractPages(@"C:\Users\a0933\Desktop\progit.pdf", @"C:\Users\a0933\Desktop\new.pdf", 8, 12);
            //如果outputpath有此檔案，就會複寫它
        }
    }
}
