using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForBuildCordova
{
    public class Buyer
    {
        public string name { get; private set; }
        public string tag { get; private set; }
        public App[] apps { get; private set; }
        public Key key { get; private set; }
        public Project project { get; private set; }

        public Buyer(string name, string tag, App[] apps, Key key)
        {
            this.name = name;
            this.tag = tag;
            this.apps = apps;
            this.key = key;

            foreach (App app in apps)
            {
                app.SetBuyer(this);
            }
        }

        public void SetProject(Project project)
        {
            this.project = project;
        }
    }
}
