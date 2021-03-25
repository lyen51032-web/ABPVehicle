﻿using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace TestProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TestProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}