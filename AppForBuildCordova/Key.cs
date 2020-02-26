using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppForBuildCordova
{
    public class Key
    {
        public string id { get; private set; }
        public string path { get; private set; }
        public string alias { get; private set; }
        public string password { get; private set; }

        public Key(string id, string path, string alias, string password = "dhkelfh")
        {
            this.id = id;
            this.path = path;
            this.alias = alias;
            this.password = password;
        }
    }
}