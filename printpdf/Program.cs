using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using printpdf.Utils;

namespace printpdf
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilPrinters.PrintPdf(new Settings
            {
                AdobePath = @"C:\Program Files (x86)\Adobe\Reader 10.0\Reader",
                GoustScriptPath = @"C:\Program Files\gs\gs9.10\bin\gswin64c.exe",
                printerName = "pr",
                AdobeFileName = "AcroRd32.exe",
               
            }, @"c:\test.pdf",Console.WriteLine);
        }
    }
}
