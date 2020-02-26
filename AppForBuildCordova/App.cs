using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppForBuildCordova
{
    public class App
    {
        public string name { get; private set; }
        public string package_name { get; private set; }
        public string version_code { get; private set; }
        public string version { get; private set; }
        public Buyer buyer { get; private set; }
        public Project project { get { return buyer.project; } }
        public Key key { get { return buyer.key; } }
        public App(string name, string package_name, string version_code, string version)
        {
            this.name = name;
            this.package_name = package_name;
            this.version_code = version_code;
            this.version = version;
        }

        public void SetBuyer(Buyer buyer)
        {
            this.buyer = buyer;
        }
        public string apkName { get { return $"{buyer.tag}_{package_name.Split('.')[2]}_{version_code}_{version}"; } }
        public void UpdateConfig(string version_code, string version)
        {
            this.version_code = version_code;
            this.version = version;
            Data.instance.SaveApp(this);
        }

    }
}