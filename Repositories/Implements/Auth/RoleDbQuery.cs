namespace svietnamAPI.Repositories.Implements.Auth
{
    public static class RoleDbQuery
    {


        public const string GetN_ByUserId_GroupCode_Basic =
        @"SELECT * FROM
        (
            SELECT rol.RoleId, rol.Code FROM AppUser use1
            JOIN UserToRole utr ON utr.UserId = use1.UserId 
            JOIN AppRole rol ON rol.RoleId = utr.RoleId
            WHERE use1.UserId = @UserId
            UNION
            SELECT rol.RoleId, rol.Code FROM AppGroup gro
            JOIN GroupToRole gtr ON gtr.GroupId = gro.GroupId
            JOIN AppRole rol ON rol.RoleId = gtr.RoleId 
            WHERE gro.Code = @GroupCode
        ) AS TBL
        ;";

    }
}