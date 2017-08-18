using InterviewProject.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Api.Test
{
    [TestClass]
    public class BusinessTextServiceTests
    {
        private BusinessTextService CUT = null;
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "text")]
        public void BusinessTextService_WriteText_NullText_ShouldThrowArgumentNullException()
        {
            CUT = new BusinessTextService(new OutputFactory(), GetMockConfigManager().Object, new Mock<ILogger>().Object);
            CUT.WriteText(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "text")]
        public void BusinessTextService_WriteText_EmptyText_ShouldThrowArgumentNullException()
        {
            CUT = new BusinessTextService(new OutputFactory(), GetMockConfigManager().Object, new Mock<ILogger>().Object);
            CUT.WriteText("");
        }
        
        [TestMethod]
        public void BusinessTextService_WriteText_OutputTypeConsole_TextHelloWorld_ShouldUseConsoleOutputAndWriteHelloWorld()
        {
            //arrange
            var consoleOutput = new Mock<IOutput>();
            var outputFactory = new Mock<IOutputFactory>();
            outputFactory.Setup(obj => obj.CreateOutput("Console")).Returns(consoleOutput.Object);

            //act
            CUT = new BusinessTextService(outputFactory.Object, GetMockConfigManager("Console").Object, new Mock<ILogger>().Object);
            CUT.WriteText("Hello World");

            //assert
            consoleOutput.Verify(obj => obj.Write("Hello World"), Times.AtLeast(1), "Write did not get called");
        }

        private Mock<IOutputFactory> GetMockOutputFactoryToThrowException()
        {
            var outputFactory = new Mock<IOutputFactory>();
            outputFactory.Setup(obj => obj.CreateOutput(It.IsAny<string>())).Throws(new Exception());
            return outputFactory;
        }

        private Mock<IConfigManager> GetMockConfigManager(string outputType = "Console", string text = "Hello World")
        {
            var configManager = new Mock<IConfigManager>();
            configManager.Setup(obj => obj.GetKey("TEXT")).Returns(text);
            configManager.Setup(obj => obj.GetKey("OUTPUT_TYPE")).Returns(outputType);
            return configManager;
        }
    }
}
