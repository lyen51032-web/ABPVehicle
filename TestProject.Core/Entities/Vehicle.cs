using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Entities
{
    [Table("Vehicle")]
    public class Vehicle : Entity<int>,IHasCreationTime,IHasModificationTime,ICreationAudited,IModificationAudited
    {
        /// <summary>
        /// 車輛類型
        /// </summary>
        public int VehicleType { get; set; }

        /// <summary>
        /// 車牌號碼
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// 里程數
        /// </summary>
        public decimal? Mileage { get; set; }


        /// <summary>
        /// 出廠日期
        /// </summary>
        public DateTime MFD { get; set; }

        /// <summary>
        /// 車輛持有者
        /// </summary>
        public int? PersonId { get; set; }

        #region Default Parameter

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最後修改者
        /// </summary>
        public long? LastModifierUserId { get; set; }

        #endregion Default Parameter
    }
}
