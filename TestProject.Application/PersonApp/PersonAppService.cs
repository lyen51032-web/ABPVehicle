using Abp.Domain.Repositories;
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
    public class PersonAppService : TestProjectAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(
            IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        /// <param name="input">傳入參數</param>
        /// <returns></returns>
        [UnitOfWork]
        public MessageModel AddPerson(PersonEditModel input)
        {
            try
            {
                Person result = new Person();
                ObjectMapper.Map(input, result);
                this._personRepository.Insert(result);

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
        /// 刪除人員
        /// </summary>
        /// <param name="id">key</param>
        /// <returns></returns>
        public MessageModel DeletePerson(int id)
        {
            try
            {
                this._personRepository.Delete(id);

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
        /// 取得所有人員
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Person> GetAllPerson()
        {
            return this._personRepository.GetAllList();
        }
    }
}