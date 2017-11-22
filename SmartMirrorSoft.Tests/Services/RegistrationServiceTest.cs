using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartMirrorSoft.Tests.Services
{
    public class RegistrationServiceTest
    {

        [Fact]
        public void ReadFromXMLFileMethodWithCorrectInputParsesCorrectly()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/ProgramlarCorrect1.xml");
            RegistrationService serv = new RegistrationService(path);

            Type regServiceType = Type.GetType("RegistrationService");
            MethodInfo xmlRead = regServiceType.GetMethod("readFromXMLFile");

            var programs = xmlRead.Invoke((object)serv, null);

        }

        [Fact]
        public void InstantiateClassWithIncorrectFilePathThrowsException()
        {
        }

        [Fact]
        public void InstantiateClassWithCorrectFilePathPasses() { }

        [Fact]
        public void ReadFromXMLFileMethodWithIncorrectInputThrowsException() { }

        [Fact]
        public void ReadFromXMLFileMethodWithMultipleProgramNamesThrowsException() { }

        [Fact]
        public void ReadFromXMLFileWithIncorrectIconPathsThrowsException() { }

    }
}
