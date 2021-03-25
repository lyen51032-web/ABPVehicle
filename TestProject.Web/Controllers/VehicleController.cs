using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestProject.Authorization;
using TestProject.VehicleApp;
using TestProject.VehicleApp.Dto;

using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using TestProject.Authorization;

using TestProject.MultiTenancy;

namespace TestProject.Web.Controllers
{
    public class VehicleController : TestProjectControllerBase
    {
        private readonly IVehicleAppService _vehicleAppService;

        public VehicleController(IVehicleAppService vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }

        /// <summary>
        /// Edit Vehicle
        /// </summary>
        /// <param name="tenantId"> </param>
        /// <returns> </returns>
        public ActionResult EditVehicleModal(int vehicleId)
        {
            var vehicleDto = _vehicleAppService.GetAllVehicle().Where(o => o.Id == vehicleId).FirstOrDefault();

            //var vResult = new VehicleListModel();
            //ObjectMapper.Map(vehicleDto, vResult);
            return View("_EditVehicleModal", vehicleDto);
        }

        // GET: Vehicle
        public ActionResult Index()
        {
            return View(new VehicleViewModel()
            {
                Vehicle = this._vehicleAppService.GetAllVehicle()
            });
        }
    }
}