using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using printpdf;

namespace ClaimEmailSender.Utils
{
    public static class UtilPrinters
    {
      
        public static void PrintPdf(Settings settings, string file2Print, Action<string> log)
        {
            Log(log, "Start PRINTING " + file2Print);
            PrintPdfByPostScript(settings, file2Print, log);
           // PrintPdfByAdobeReader(settings, file2Print, log);
            Log(log, "End PRINTING " + file2Print);

        }
        
        static void PrintPdfByPostScript(Settings settings, string file2Print, Action<string> log)
        {
            // http://www.ghostscript.com/download/gsdnld.html
            Log(log, "Start Print Pdf By PostScript " + file2Print);

            ProcessStartInfo psInfo = new ProcessStartInfo();
            Log(log, "Print Pdf By PostScript " + settings.printerName);
            psInfo.Arguments = String.Format(" -dPrinted -dBATCH -dNOPAUSE -dNOSAFER -q -dNumCopies=1 -sDEVICE=ljet4 -sOutputFile=\"\\\\spool\\{0}\" \"{1}\"", settings.printerName, file2Print);
            psInfo.FileName = settings.GoustScriptPath; //@"C:\Program Files\gs\gs9.10\bin\gswin64c.exe";
            psInfo.UseShellExecute = false;
            Process process = Process.Start(psInfo);
            Log(log, "End Print Pdf By PostScript " + file2Print);
        }
        
        static void PrintPdfByAdobeReader(Settings settings, string file2Print, Action<string> log)
        {
            Log(log, "Start Print Pdf By AdobeReader " + file2Print);
            var pNewProcess = new Process();
            Log(log, "Configure Process StartInfo Printer ");
             ConfigureProcessStartInfo(pNewProcess, file2Print, settings, log);
            Log(log, "End Print Pdf By AdobeReader " + file2Print);

        }
      
        static void ConfigureProcessStartInfo(Process pNewProcess, string file2Print, Settings settings, Action<string> log)
        {
            
            pNewProcess.StartInfo.WorkingDirectory = settings.AdobePath;
            pNewProcess.StartInfo.FileName = settings.AdobePath + "\\" + settings.AdobeFileName;
            pNewProcess.StartInfo.Arguments = "/n /s /h /t \"" + @file2Print + "\" \"" + settings.printerName + "\"";
            pNewProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pNewProcess.StartInfo.CreateNoWindow = false;
            pNewProcess.StartInfo.UseShellExecute = false;
        }
    

        static void Log(Action<string> log, string s)
        {
            if (log != null)
            {
                log(s);
            }
            Console.WriteLine(s);
        }
    }
}
