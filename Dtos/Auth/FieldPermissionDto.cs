namespace svietnamAPI.Dtos.Auth
{
    public class FieldPermissionDto
    {
        public int FieldPermissionId { get; set; }
        public int EntityPermissionId { get; set; }
        public int FieldId { get; set; }
        public bool IsAllowed { get; set; }

        public EntityPermissionDto EntityPermission { get; set; }
        public FieldDto Field { get; set; }

    }
}