using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Api
{
    public interface IConfigManager
    {
        string GetKey(string key);
    }

    public class ConfigManager : IConfigManager
    {
        public string GetKey(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
            {
                throw new Exception($"{key} appSetting is required");
            }

            return ConfigurationManager.AppSettings[key];
        }
    }
}
