using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppForBuildCordova
{
    public class Project
    {
        public string name { get; private set; }
        public string path { get; private set; }
        public Buyer[] buyers { get; private set; }

        public Project(string name, string path, Buyer[] buyers)
        {
            this.name = name;
            this.path = path;
            this.buyers = buyers;
            foreach (Buyer buyer in buyers)
            {
                buyer.SetProject(this);
            }
        }
    }
}