using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppForBuildCordova
{
    public struct DataItem
    {
        public string name;
        public string company;
        public string age;
                
        public override string ToString()
        {
            return $"name: {name}\ncompany: {company}\nage: {age}";
        }
    }
}