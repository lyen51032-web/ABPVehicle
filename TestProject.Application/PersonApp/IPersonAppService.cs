using Abp.Application.Services;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Common.Dto;
using TestProject.Entities;
using TestProject.PersonApp.Dto;

namespace TestProject.PersonApp
{
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// 新增人員
        /// </summary>
        /// <param name="input">傳入參數</param>
        /// <returns></returns>
        [UnitOfWork]
        MessageModel AddPerson(PersonEditModel input);

        /// <summary>
        /// 刪除人員
        /// </summary>
        /// <param name="id">key</param>
        /// <returns></returns>
        MessageModel DeletePerson(int id);

        /// <summary>
        /// 取得所有人員
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Person> GetAllPerson();
    }
}