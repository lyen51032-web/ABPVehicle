using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using TestProject.Common.Dto;
using TestProject.Entities;
using TestProject.VehicleApp.Dto;

namespace TestProject.VehicleApp
{
    /// <summary>
    /// 新增/編輯車輛
    /// </summary>
    public class VehicleAppService : TestProjectAppServiceBase, IVehicleAppService
    {
        private readonly IRepository<Person> _personRepository;

        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleAppService(IRepository<Vehicle> vehicleRepository, IRepository<Person> personRepository)
        {
            _vehicleRepository = vehicleRepository;
            _personRepository = personRepository;
        }

        /// <summary>
        /// 新進車輛
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public MessageModel AddVehicle(VehicleEditModel input)
        {
            try
            {
                Vehicle result = new Vehicle();
                ObjectMapper.Map(input, result);
                this._vehicleRepository.Insert(result);

                return new MessageModel()
                {
                    isSuccess = true,
                    title = "新增成功"
                };
            }
            catch (Exception ex)
            {
                return new MessageModel()
                {
                    isSuccess = false,
                    title = "新增失敗",
                    message = ex.Message
                };
            }
        }

        /// <summary>
        /// 刪除車輛
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        public MessageModel DeleteVehicle(int id)
        {
            try
            {
                this._vehicleRepository.Delete(id);

                return new MessageModel()
                {
                    isSuccess = true,
                    title = "刪除成功"
                };
            }
            catch (Exception ex)
            {
                return new MessageModel()
                {
                    isSuccess = false,
                    title = "刪除失敗",
                    message = ex.Message
                };
            }
        }

        /// <summary>
        /// 編輯車輛
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public MessageModel EditVehicle(VehicleListModel input)
        {
            try
            {
                Vehicle result = _vehicleRepository.Get(input.Id);
                ObjectMapper.Map(input, result);
                this._vehicleRepository.Update(result);

                return new MessageModel()
                {
                    isSuccess = true,
                    title = "編輯成功"
                };
            }
            catch (Exception ex)
            {
                return new MessageModel()
                {
                    isSuccess = false,
                    title = "編輯失敗",
                    message = ex.Message
                };
            }
        }

        /// <summary>
        /// 取得所有車輛
        /// </summary>
        /// <returns> </returns>
        public List<VehicleListModel> GetAllVehicle()
        {
            //List<VehicleListModel> result = new List<VehicleListModel>();
            var query = (from a in _personRepository.GetAll()
                         join b in _vehicleRepository.GetAll() on a.Id equals b.PersonId
                         select new VehicleListModel
                         {
                             VehicleType = b.VehicleType,
                             PlateNumber = b.PlateNumber,
                             Mileage = b.Mileage,
                             MFD = b.MFD,
                             PersonId = b.PersonId,
                             PersonName = a.Name,
                         }).ToList();

            //return this._vehicleRepository.GetAllList();
            return query;
        }
    }
}