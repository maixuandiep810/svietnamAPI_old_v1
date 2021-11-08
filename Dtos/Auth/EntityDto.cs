using System.Collections.Generic;
namespace svietnamAPI.Dtos.Auth
{
    public class EntityDto
    {
        public int EntityId { get; set; }
        public string Code { get; set; }

        public List<FieldDto> Fields { get; set; }
        public List<EntityPermissionDto> EntityPermissions { get; set; }
    }
}