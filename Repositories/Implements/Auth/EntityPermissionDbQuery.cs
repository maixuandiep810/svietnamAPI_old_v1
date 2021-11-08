namespace svietnamAPI.Repositories.Implements.Auth
{
    public static class EntityPermissionDbQuery
    {
        public const string Get1_EP =
        @"SELECT * FROM EntityPermissions enp
        JOIN Entities ent ON ent.EntityId = enp.EntityId
        JOIN FieldPermissions fip ON fip.EntityPermissionId = enp.EntityPermissionId 
        JOIN Fields fie ON fie.FieldId = fip.FieldId
        JOIN Roles rol ON rol.RoleId = enp.RoleId
        WHERE enp.IsObjectPermission = '0' 
        AND ent.Code = @EntityCode
        AND enp.ActionType = @ActionType
        AND rol.Code IN @RoleCodes
        ";
        public const string Get1_EP_OP =
        @"SELECT * FROM EntityPermissions enp
        JOIN Entities ent ON ent.EntityId = enp.EntityId
        JOIN FieldPermissions fip ON fip.EntityPermissionId = enp.EntityPermissionId 
        JOIN Fields fie ON fie.FieldId = fip.FieldId
        JOIN Roles rol ON rol.RoleId = enp.RoleId
        JOIN ObjectPermissions obp ON obp.EntityPermissionId = enp.EntityPermissionId
        WHERE enp.IsObjectPermission = '1' 
        AND ent.Code = @EntityCode
        AND enp.ActionType = @ActionType
        AND rol.Code IN @RoleCodes
        AND obp.UserId = @UserId
        ";
    }
}