using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AppForBuildCordova
{
    class AppConfig
    {
        public bool ChangeConfigFile()
        {
            App app = Data.instance.GetApp();
            string newVersionCode = (Convert.ToInt32(app.version_code) + 1).ToString();
            string[] versionArr = app.version.Split('.');
            string newVersion = $"{versionArr[0]}.{versionArr[1]}.{Convert.ToInt32(app.version.Split('.')[2]) + 1}";
            app.UpdateConfig(newVersionCode, newVersion);
            Debug.WriteLine("appConfig");
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(app.project.path + "config.xml");

            XmlNamespaceManager ns = new XmlNamespaceManager(xDoc.NameTable);
            ns.AddNamespace("cordova", "http://www.w3.org/ns/widgets");

            XmlElement xRoot = xDoc.DocumentElement;

            xRoot.SelectSingleNode("@id").Value = app.package_name;
            xRoot.SelectSingleNode("@android-versionCode").Value = app.version_code;
            xRoot.SelectSingleNode("@version").Value = app.version;

            xRoot.SelectSingleNode("cordova:name", ns).InnerText = app.name;


            xDoc.Save(app.project.path + "config.xml");
            //xDoc.Save("c:/WorkSpace/AppForBuildCordova/AppForBuildCordova/Data/save_config.xml");
            return true;
        }

        App GetUpdatedApp()
        {
            App app = Data.instance.GetApp();
            
            return app;
        }

        public bool ChangeConfigFile(AppInfo appInfo)
        {
            Debug.WriteLine("appConfig");
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(appInfo.path + "config.xml");
            //xDoc.Load("c:/WorkSpace/AppForBuildCordova/AppForBuildCordova/Data/config.xml");

            XmlNamespaceManager ns = new XmlNamespaceManager(xDoc.NameTable);
            ns.AddNamespace("cordova", "http://www.w3.org/ns/widgets");

            XmlElement xRoot = xDoc.DocumentElement;

            xRoot.SelectSingleNode("@id").Value = appInfo.package_name;
            xRoot.SelectSingleNode("@android-versionCode").Value = appInfo.version_code;
            xRoot.SelectSingleNode("@version").Value = appInfo.version;

            xRoot.SelectSingleNode("cordova:name", ns).InnerText = appInfo.app_name;


            //xDoc.Save(appInfo.path + "save_config.xml");
            xDoc.Save("c:/WorkSpace/AppForBuildCordova/AppForBuildCordova/Data/save_config.xml");
            return true;
        }
    }
}
