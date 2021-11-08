using System;
using System.Collections.Generic;
namespace svietnamAPI.Dtos.Auth
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Displayname { get; set; }
        public string Description { get; set; }

        public List<EndpointDto> Endpoints { get; set; }
        public List<EntityPermissionDto> EntityPermissions { get; set; }
        public List<UserDto> Users { get; set; }
        public List<GroupDto> Groups { get; set; }
    }
}