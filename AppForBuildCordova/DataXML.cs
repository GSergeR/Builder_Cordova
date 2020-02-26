using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace AppForBuildCordova
{
    public class DataXML : iData
    {
        XmlDocument xDoc = new XmlDocument();
        XmlElement xRoot;
        readonly string pathToDataFolder = "C://WorkSpace//AppForBuildCordova//AppForBuildCordova//Data//XML//";
        readonly string xmlFileName;

        public DataXML()
        {
            xmlFileName = "apps.xml";
            print(pathToDataFolder + "" + xmlFileName);
            xDoc.Load(pathToDataFolder + "" + xmlFileName);
            xRoot = xDoc.DocumentElement;
        }

        public Project[] projects
        {
            get
            {
                List<Project> projects = new List<Project>();

                XmlNodeList projects_xml = xRoot.SelectNodes("project");
                print("projects_xml.Count " + projects_xml.Count);
                foreach (XmlNode project_xml in projects_xml)
                {
                    string project_name = project_xml.SelectSingleNode("@name").Value;
                    string project_path = project_xml.SelectSingleNode("path").InnerText;
                    Project project = new Project(project_name, project_path, GetBuyers(project_xml));
                    projects.Add(project);
                }
                return projects.ToArray();
            }
        }

        Buyer[] GetBuyers(XmlNode project_xml)
        {
            List<Buyer> buyers = new List<Buyer>();
            XmlNodeList buyers_xml = project_xml.SelectNodes("buyer");

            foreach (XmlNode buyer_xml in buyers_xml)
            {
                string name = buyer_xml.SelectSingleNode("@name").Value;
                string tag = buyer_xml.SelectSingleNode("short").InnerText;

                Buyer buyer = new Buyer(name, tag, GetApps(buyer_xml), GetKey(buyer_xml));
                buyers.Add(buyer);
            }
            return buyers.ToArray();
        }

        App[] GetApps(XmlNode buyer_xml)
        {
            List<App> apps = new List<App>();
            XmlNodeList apps_xml = buyer_xml.SelectNodes("app_info");

            foreach (XmlNode app_xml in apps_xml)
            {
                string name = app_xml.SelectSingleNode("name").InnerText;
                string package_name = app_xml.SelectSingleNode("package_name").InnerText;
                string version_code = app_xml.SelectSingleNode("version_code").InnerText;
                string version = app_xml.SelectSingleNode("version").InnerText;

                App app = new App(name, package_name, version_code, version);
                apps.Add(app);
            }

            return apps.ToArray();
        }

        Key GetKey(XmlNode buyer_xml)
        {
            string key_id = buyer_xml.SelectSingleNode("short").InnerText;
            print("key_id " + key_id);
            XmlNode key_xml = xRoot.SelectSingleNode($"keys/key[@id='{key_id}']");
            string path = key_xml.SelectSingleNode("path").InnerText;
            string alias = key_xml.SelectSingleNode("alias").InnerText;

            return new Key(key_id, path, alias);
        }

        public void SaveApp(App app)
        {
            Backup();
            XmlNode app_xml = xRoot.SelectSingleNode($"//app_info[package_name='{app.package_name}']");
            app_xml.SelectSingleNode("version_code").InnerText = app.version_code;
            app_xml.SelectSingleNode("version").InnerText = app.version;
            SaveFile();
        }








        //public string[] GetProjectList
        //{
        //    get
        //    {
        //        List<string> result = new List<string>();

        //        XmlNodeList childnodes = xRoot.SelectNodes("project");
        //        foreach (XmlNode item in childnodes)
        //        {
        //            result.Add(item.SelectSingleNode("@name").Value);
        //        }

        //        return result.ToArray();
        //    }
        //}


        void print(string text)
        {
            Debug.WriteLine(text);
        }

        public void AddElement(DataItem newData)
        {
            XmlElement userElem = xDoc.CreateElement("user");
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");
            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");

            XmlText nameText = xDoc.CreateTextNode(newData.name);
            XmlText companyText = xDoc.CreateTextNode(newData.company);
            XmlText ageText = xDoc.CreateTextNode(newData.age);

            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);

            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(companyElem);
            userElem.AppendChild(ageElem);

            xRoot.AppendChild(userElem);
            SaveFile();
        }

        void SaveFile()
        {
            xDoc.Save(pathToDataFolder + "" + xmlFileName);
        }

        void Backup()
        {
            xDoc.Save(pathToDataFolder + "backup_" + xmlFileName);
        }
        


        //public string[] GetBuyerList(int index)
        //{
        //    List<string> result = new List<string>();
        //    XmlNode childnodes = xRoot.SelectSingleNode("project[" + (index + 1) + "]");
        //    foreach (XmlNode item in childnodes.SelectNodes("buyer"))
        //    {
        //        result.Add(item.SelectSingleNode("@name").Value);
        //    }

        //    return result.ToArray();
        //}

        //public AppInfo GetProjectInfo(int index_app, int index_buyer)
        //{
        //    AppInfo result = new AppInfo();

        //    XmlNode app = xRoot.SelectSingleNode("project[" + (index_app + 1) + "]");
        //    result.path = app.SelectSingleNode("path").InnerText;

        //    XmlNode buyer = app.SelectSingleNode("buyer[" + (index_buyer + 1) + "]");
        //    result.shortBuyerName = buyer.SelectSingleNode("short").InnerText;

        //    //XmlNode app_info = app.SelectSingleNode("buyer[" + (index_buyer + 1) + "]/app_info");
        //    XmlNode app_info = buyer.SelectSingleNode("app_info");

        //    result.app_name = app_info.SelectSingleNode("name").InnerText;
        //    result.package_name = app_info.SelectSingleNode("package_name").InnerText;
        //    result.version_code = app_info.SelectSingleNode("version_code").InnerText;
        //    result.version = app_info.SelectSingleNode("version").InnerText;
        //    result.key_path = app_info.SelectSingleNode("key").InnerText;
        //    result.key_alias = app_info.SelectSingleNode("key_alias").InnerText;

        //    return result;
        //}



        //public int AppCount => xRoot.SelectNodes("app").Count;


    }
}