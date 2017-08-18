using InterviewProject.Api;
using InterviewProject.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();

            try
            {
                if(ConfigurationManager.AppSettings[StringConstants.Configuration.TEXT] == null)
                {
                    throw new Exception("TEXT appSetting is required.");
                }

                IBusinessTextService businessTextService = new BusinessTextService(new OutputFactory(), new ConfigManager(), new ConsoleLogger());
                businessTextService.WriteText(ConfigurationManager.AppSettings[StringConstants.Configuration.TEXT]);
                
                Console.WriteLine("Program complete.  Press any key to continue.");
                Console.Read();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                logger.WriteError("Unexpected error occurred.", ex);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.Read();
                Environment.Exit(-1);
            }
        }
    }
}
