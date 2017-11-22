using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMirrorSoft.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartMirrorSoftTests.Services
{
    [TestClass]
    public class RegistrationServiceTest
    {
        [TestMethod]
        public void ReadFromXMLFileMethodWithCorrectInputParsesCorrectly()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Resources/ProgramlarCorrect1.xml");
            RegistrationService serv = new RegistrationService(path);

            Type regServiceType = Type.GetType("RegistrationService");
            MethodInfo xmlRead = regServiceType.GetMethod("readFromXMLFile");

            var programs = xmlRead.Invoke((object)serv, null);

            Assert.AreEqual(serv.GetAvailableApps().Count, 2);
            Assert.AreEqual(serv.GetInstalledApps().Count, 8);
            Assert.AreEqual(serv.GetAllApps().Count, 10);
        }

        [TestMethod]
        public void InstantiateClassWithIncorrectFilePathThrowsException()
        {
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Resources/ProgramlarThrowsExcIncorrectPathToFile.xml");
                RegistrationService serv = new RegistrationService(path);

            });
        }
        
        [TestMethod]
        public void ReadFromXMLFileMethodWithMissingProgramNameThrowsException()
        {
            Assert.ThrowsException<FormatException>(() =>
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Resources/ProgramlarThrowsExcMissingProgramName1.xml");
                RegistrationService serv = new RegistrationService(path);

                Type regServiceType = Type.GetType("RegistrationService");
                MethodInfo xmlRead = regServiceType.GetMethod("readFromXMLFile");

                var programs = xmlRead.Invoke((object)serv, null);
            });
        }

        [TestMethod]
        public void ReadFromXMLFileMethodWithMultipleProgramNamesThrowsException()
        {
            Assert.ThrowsException<FormatException>(() =>
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Resources/ProgramlarThrowsExcMultipleProgramSameNames1.xml");
                RegistrationService serv = new RegistrationService(path);

                Type regServiceType = Type.GetType("RegistrationService");
                MethodInfo xmlRead = regServiceType.GetMethod("readFromXMLFile");

                var programs = xmlRead.Invoke((object)serv, null);
            });
        }


        [TestMethod]
        public void ReadFromXMLFileWithIncorrectIconPathsThrowsException()
        {
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Resources/ProgramlarThrowsExcIncorrectIconfilepath.xml");
                RegistrationService serv = new RegistrationService(path);

                Type regServiceType = Type.GetType("RegistrationService");
                MethodInfo xmlRead = regServiceType.GetMethod("readFromXMLFile");

                var programs = xmlRead.Invoke((object)serv, null);
            });
        }

    }
}
