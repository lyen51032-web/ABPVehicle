using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.VehicleApp.Dto
{
    public class VehicleListModel
    {
        /// <summary>
        /// key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 出廠日期
        /// </summary>
        public DateTime MFD { get; set; }

        /// <summary>
        /// 里程數
        /// </summary>
        public decimal? Mileage { get; set; }

        /// <summary>
        /// 車輛持有者
        /// </summary>
        public int? PersonId { get; set; }

        public string PersonName { get; set; }

        /// <summary>
        /// 車牌號碼
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// 車輛類型
        /// </summary>
        public int VehicleType { get; set; }
    }
}