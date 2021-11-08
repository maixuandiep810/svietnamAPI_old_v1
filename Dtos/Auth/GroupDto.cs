using System;
using System.Collections.Generic;
namespace svietnamAPI.Dtos.Auth
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string Code { get; set; }
        
        public List<UserDto> Users { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}