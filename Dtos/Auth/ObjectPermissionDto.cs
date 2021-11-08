namespace svietnamAPI.Dtos.Auth
{
    public class ObjectPermissionDto
    {
        public int ObjectPermissionId { get; set; }
        public int EntityPermissionId { get; set; }
        public int UserId { get; set; }
        public int ObjectId { get; set; }

        public UserDto User { get; set; }
        public EntityPermissionDto EntityPermission { get; set; }
    }
}