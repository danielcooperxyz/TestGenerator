using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.Models
{
    public class HomeModel
    {
        public string TypeOfClassToTest { get; set; }

        public string ClassToTest { get; set; }

        public IDictionary<string, string> ClassParameters { get; set; }
    }
}