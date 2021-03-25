using System.Collections.Generic;
using TestProject.Roles.Dto;
using TestProject.Users.Dto;

namespace TestProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}