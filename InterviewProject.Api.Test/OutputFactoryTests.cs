using InterviewProject.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Api.Test
{
    [TestClass]
    public class OutputFactoryTests
    {
        private OutputFactory CUT = null;

        [TestMethod]
        public void OutputFactory_CreateOutput_ConsoleOutputType_ShouldReturnConsoleOutput()
        {
            CUT = new OutputFactory();
            var result = CUT.CreateOutput("Console");
            Assert.IsInstanceOfType(result, typeof(ConsoleOutput));
        }

        [TestMethod]
        public void OutputFactory_CreateOutput_SqlDatabaseOutputType_ShouldReturnSqlDatabaseOutput()
        {
            CUT = new OutputFactory();
            var result = CUT.CreateOutput("SqlDatabase");
            Assert.IsInstanceOfType(result, typeof(SqlDatabaseOutput));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void OutputFactory_CreateOutput_InvalidOutputType_ShouldThrowNotSupportedException()
        {
            CUT = new OutputFactory();
            CUT.CreateOutput("INVALID_OUTPUT_TYPE");
        }
    }
}
