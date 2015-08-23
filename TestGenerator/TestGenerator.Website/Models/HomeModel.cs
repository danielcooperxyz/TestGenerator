using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestGenerator.Website.Models
{
    public class HomeModel
    {
        [StringLength(250)]
        public string TypeOfClassToTest { get; set; }

        [StringLength(250)]
        public string ClassToTest { get; set; }

        public IDictionary<string, string> ClassParameters { get; set; }
    }
}