using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities;

namespace TestProject.VehicleApp.Dto
{
    /// <summary>
    /// 查詢結果
    /// </summary>
    public class VehicleViewModel
    {
        public List<VehicleListModel> Vehicle { get; set; }
    }
}