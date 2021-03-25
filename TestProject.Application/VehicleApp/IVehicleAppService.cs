using Abp.Application.Services;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Common.Dto;
using TestProject.Entities;
using TestProject.VehicleApp.Dto;

namespace TestProject.VehicleApp
{
    public interface IVehicleAppService : IApplicationService
    {
        /// <summary>
        /// 新增車輛
        /// </summary>
        /// <param name="input"> 傳入參數 </param>
        /// <returns> </returns>
        [UnitOfWork]
        MessageModel AddVehicle(VehicleListModel input);

        /// <summary>
        /// 刪除車輛
        /// </summary>
        /// <param name="id"> key </param>
        /// <returns> </returns>
        MessageModel DeleteVehicle(int id);

        /// <summary>
        /// 編輯車輛
        /// </summary>
        /// <param name="input"> 傳入參數 </param>
        /// <returns> </returns>
        MessageModel EditVehicle(VehicleListModel input);

        /// <summary>
        /// 取得所有車輛
        /// </summary>
        /// <returns> </returns>
        //IReadOnlyList<Vehicle> GetAllVehicle();

        List<VehicleListModel> GetAllVehicle();

        List<Person> GetRegisterPerson();
    }
}