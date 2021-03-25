using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.PersonApp.Dto
{
    /// <summary>
    /// 新增/編輯人員
    /// </summary>
    public class PersonEditModel
    {
        /// <summary>
        /// key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}