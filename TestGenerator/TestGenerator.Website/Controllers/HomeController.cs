﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestGenerator.Website.Models;

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
        public string GetNullParamTests(HomeModel model)
        {
            return string.Empty;
        }
	}
}