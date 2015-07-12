using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.Models
{
    public class HomeModel
    {
        public string TypeOfClassToTest { get; set; }

        public string ClassToTest { get; set; }

        public IList<string> ClassParameters { get; set; }
    }
}