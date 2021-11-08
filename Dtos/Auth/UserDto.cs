using System.Collections.Generic;
namespace svietnamAPI.Dtos.Auth
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public int GroupId { get; set; }

        public GroupDto Group { get; set; }
        public List<RoleDto> Roles { get; set; }
        public List<ObjectPermissionDto> ObjectPermissions { get; set; }
    }
}