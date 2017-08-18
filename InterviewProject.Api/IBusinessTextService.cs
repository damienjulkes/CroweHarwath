using InterviewProject.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Api
{
    public interface IBusinessTextService
    {
        void WriteText(string text);
    }

    public class BusinessTextService : IBusinessTextService
    {
        private readonly IOutputFactory _outputFactory;
        private readonly ILogger _logger;
        private readonly IConfigManager _configManager;

        public BusinessTextService(IOutputFactory outputFactory, IConfigManager configManager, ILogger logger)
        {
            _configManager = configManager ?? throw new ArgumentNullException("configManager");
            _logger = logger ?? throw new ArgumentNullException("logger");
            _outputFactory = outputFactory ?? throw new ArgumentNullException("outputFactory");
        }

        public void WriteText(string text)
        {
            if(String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            try
            {
                var output = _outputFactory.CreateOutput(GetOutputType());
                output.Write(text);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"An error occurred while trying to write the business text: {text}", ex);
                throw;
            }
        }

        private string GetOutputType()
        {
            return _configManager.GetKey(StringConstants.Configuration.OUTPUT_TYPE);
        }
    }
}
