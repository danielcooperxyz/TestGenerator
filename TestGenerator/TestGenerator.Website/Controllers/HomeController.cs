using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestGenerator.Website.Models;
using TestGenerator.Website.Services;

namespace TestGenerator.Website.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(new HomeModel());
        }

        [HttpPost]
        public string GetTestFile(HomeModel model)
        {
            TestGeneratorService testGenService = new TestGeneratorService();

            var file = testGenService.CreateTestFileStart(model.TypeOfClassToTest);

            file += testGenService.CreateParameters(model.ClassParameters);

            file += testGenService.CreateSetup(model.ClassParameters);

            file += testGenService.CreateNullParamTests(model.ClassParameters);

            file += testGenService.CreateGetInstance(model.TypeOfClassToTest, model.ClassParameters.Values.ToList());

            file += testGenService.CreateTestFileEnd();

            return HttpUtility.HtmlEncode(file);
        }
	}
}