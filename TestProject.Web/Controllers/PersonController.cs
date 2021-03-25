using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.PersonApp;
using TestProject.PersonApp.Dto;

namespace TestProject.Web.Controllers
{
    public class PersonController : TestProjectControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService persoAppService)
        {
            _personAppService = persoAppService;
        }

        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new PersonViewModel()
            {
                Persons = this._personAppService.GetAllPerson()
            });
        }
    }
}