using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Api
{
    public interface IOutputFactory
    {
        IOutput CreateOutput(string outputType);
    }

    public class OutputFactory : IOutputFactory
    {
        public IOutput CreateOutput(string outputType)
        {
            string fullyQualifiedName = $"InterviewProject.Api.{outputType}Output";
            var type = Assembly.GetExecutingAssembly().GetType(fullyQualifiedName);

            if (type == null)
            {
                throw new NotSupportedException($"The output type: {outputType} is not currently supported");
            }

            return Activator.CreateInstance(type) as IOutput;
        }
    }
    /// <summary>
    /// Output
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Display output
        /// </summary>
        /// <param name="content">content to be written</param>
        void Write(string content);
    }

    /// <summary>
    /// Content written to Console.
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    /// <summary>
    /// Content written to DB.
    /// </summary>
    public class SqlDatabaseOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine("Not supported at the moment, but will write to SQL DB");
        }
    }
}
