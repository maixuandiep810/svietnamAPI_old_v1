using System.Collections.Generic;

namespace svietnamAPI.Dtos.Auth
{
    public class EntityPermissionDto
    {
        public int EntityPermissionId { get; set; }
        public string Code { get; set; }
        public string Displayname { get; set; }
        public string Description { get; set; }
        public int EntityId { get; set; }
        public string ActionType { get; set; }
        public int RoleId { get; set; }
        public bool IsObjectPermission { get; set; }

        public EntityDto Entity { get; set; }
        public List<FieldPermissionDto> FieldPermissions { get; set; }
        public RoleDto Role { get; set; }
        public List<ObjectPermissionDto> ObjectPermissions { get; set; }
    }
}