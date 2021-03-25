using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities;

namespace TestProject.PersonApp.Dto
{
    /// <summary>
    /// 查詢結果
    /// </summary>
    public class PersonViewModel
    {
        public IReadOnlyList<Person> Persons { get; set; }
    }
}