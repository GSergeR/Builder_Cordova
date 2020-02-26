using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppForBuildCordova
{
    public interface iData
    {
        Project[] projects { get; }
        void SaveApp(App app);


        //string[] GetProjectList { get; }
        //string[] GetBuyerList(int index);

        //void AddElement(DataItem newData);
        //int AppCount { get; }
        //AppInfo GetProjectInfo(int index_app, int index_buyer);
    }
}