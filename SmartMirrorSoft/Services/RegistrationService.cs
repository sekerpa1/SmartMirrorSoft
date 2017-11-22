using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMirrorSoft.Models;
using Windows.ApplicationModel;
using System.IO;
using System.Xml.Linq;
using System.Resources;

namespace SmartMirrorSoft.Services
{
    public class RegistrationService : IRegistrationService
    {
        private List<BaseRunnableApp> _AvailableApps;
        public List<BaseRunnableApp> AvailableApps
        {
            get
            {
                if (_AvailableApps == null)
                {
                    // initialises apps based on file
                    readFromXMLFile();
                }

                return _AvailableApps;
            }
        }

        private string _PathToPrograms;

        private string _PathToIcons;

        public RegistrationService()
        {
            //check whether resources.resw exists

            // check whether path is correct
            if (!File.Exists((string) App.Current.Resources["PathToPrograms"]))
            {
                throw new FileNotFoundException("Please supply a correct path to the program file.");
            }
            // check whether icon directory is correct
            if (!Directory.Exists((string)App.Current.Resources["PathToIcons"]))
            {
                throw new FileNotFoundException("Please supply a correct path to the icons file.");
            }

            this._PathToPrograms = (string)App.Current.Resources["PathToPrograms"];
            this._PathToIcons = (string)App.Current.Resources["PathToIcons"];
        }

        public void InstallApp(string name)
        {
            changeAppState(name, false);

            // update the programs file
            var loadedData = XDocument.Load(_PathToPrograms);
            var program = loadedData.Element("programs")
                .Elements("app")
                .Where(e => e.Element("name")
                .Value.Equals(name))
                .Single();

            program.Element("installed").Value = "Yes";
            var writer = loadedData.CreateWriter();
            loadedData.Save(writer);


        }

        public void UninstallApp(string name)
        {
            changeAppState(name, true);
        }
        
        public List<BaseRunnableApp> GetAllApps()
        {
            return _AvailableApps;
        }

        public List<BaseRunnableApp> GetInstalledApps()
        {
            return _AvailableApps.Where(x => x.Installed).ToList();
        }

        public List<BaseRunnableApp> GetAvailableApps()
        {
            return _AvailableApps.Where(x => !x.Installed).ToList();
        }

        private void readFromXMLFile()
        {

            XDocument loadedData = XDocument.Load(_PathToPrograms);
            var data = from query in loadedData.Descendants("app")
                       select new BaseRunnableApp
                       {
                           Name = (string)query.Element("name"),
                           Price = (string)query.Element("price"),
                           ClassName = (string)query.Element("classname"),
                           Version = (string)query.Element("version"),
                           Description = (string)query.Element("description"),
                           IconPath = (string)query.Element("icon"),
                           Installed = query.Element("installed").Equals(null) ? true : query.Element("installed").Equals("Yes")
                       };

            var dic = new Dictionary<string, string>();

            // check for name duplicates
            foreach (var item in data)
            {
                if (dic.ContainsKey(item.Name) || item.Name.Equals(string.Empty))
                {
                    throw new FormatException("The file 'Programs.xml' contains duplicates in names.");
                }
                dic.Add(item.Name, item.Name);
            }
            
            // check Icon paths
            foreach (var item in data)
            {
                if (!File.Exists(Path.Combine(_PathToIcons, item.IconPath)))
                {
                    throw new FileNotFoundException(string.Format("The program contains incorrect icon path : '{0}'", item.IconPath));
                }
                    
            }


            _AvailableApps = new List<BaseRunnableApp>();
            foreach (var item in data)
            {
                try
                {
                    var type = Type.GetType(item.ClassName);
                    var app = Activator.CreateInstance(type);
                    app = item;
                    _AvailableApps.Add((BaseRunnableApp)app);
                }
                catch (TypeLoadException e)
                {
                    throw new FormatException("The program contains incorrect class names.");
                }
            }

        }

        /// <summary>
        /// Installs or uninstalls the app specified by name
        /// </summary>
        /// <param name="name">name of the app</param>
        /// <param name="doUninstall">install/uninstall flag</param>
        private void changeAppState(string name, bool doUninstall)
        {
            foreach (var item in _AvailableApps)
            {
                if (item.Name.Equals(name))
                {
                    item.Installed = !doUninstall;
                }
            }
        }

    }
}
