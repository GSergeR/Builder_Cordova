using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForBuildCordova
{
    public class Data
    {
        static Data instanceMain;

        iData source;
        Project[] projects;

        Project currentProject;
        Buyer currentBuyer;
        App currentApp;

        public static Data instance
        {
            get
            {
                if (instanceMain == null)
                    instanceMain = new Data();
                return instanceMain;
            }
        }

        private Data()
        {
            source = new DataXML();
            projects = source.projects;
        }

        public void SetProject(int index)
        {
            currentProject = projects[index];
        }
        public void SetBuyer(int index)
        {
            currentBuyer = currentProject.buyers[index];
        }
        public void SetApp(int index)
        {
            currentApp = currentBuyer.apps[index];
        }

        public App GetApp()
        {
            return currentApp;
        }


        public string[] GetProjectsString()
        {
            string[] result = new string[projects.Length];

            for (int i = 0; i < projects.Length; i++)
            {
                result[i] = projects[i].name;
            }

            return result;
        }

        public string[] GetBuyersString()
        {
            string[] result = new string[currentProject.buyers.Length];

            for (int i = 0; i < currentProject.buyers.Length; i++)
            {
                result[i] = currentProject.buyers[i].name;
            }

            return result;
        }

        public string[] GetAppsString()
        {
            string[] result = new string[currentBuyer.apps.Length];

            for (int i = 0; i < currentBuyer.apps.Length; i++)
            {
                result[i] = currentBuyer.apps[i].name;
            }

            return result;
        }

        public void SaveApp(App app)
        {
            source.SaveApp(app);
        }






        //public AppInfo GetProjectInfo(int index_app, int index_buyer)
        //{
        //    return source.GetProjectInfo(index_app, index_buyer);
        //}
        //public string[] GetBuyerList(int indexApp)
        //{
        //    return source.GetBuyerList(indexApp);
        //}

        //public string[] GetAppList(int index_app, int index_buyer)
        //{
        //    //return source.GetBuyerList(indexApp);
        //    return new string[0];
        //}

        ////public string[] GetAppsList => source.GetAppsList;

        //public int AppCount => source.AppCount;

        //public string[] GetProjectList => source.GetProjectList;

        //public void AddElement(DataItem newData)
        //{
        //    source.AddElement(newData);
        //}

    }
}
