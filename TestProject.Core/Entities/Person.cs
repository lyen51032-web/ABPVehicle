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
    [Table("Person")]
    public class Person : Entity<int>, IHasCreationTime, IHasModificationTime, ICreationAudited, IModificationAudited
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 關聯車輛
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

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