using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Common
{
    public interface ILogger
    {
        void WriteInfo(string text);
        void WriteError(string text, Exception ex);
    }

    public class ConsoleLogger : ILogger
    {
        public void WriteError(string text, Exception ex)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss tt")}] | ERROR | ${text} | Exception: ${ex.ToString()}");
        }

        public void WriteInfo(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss tt")}] | INFO | ${text}");
        }
    }
}
