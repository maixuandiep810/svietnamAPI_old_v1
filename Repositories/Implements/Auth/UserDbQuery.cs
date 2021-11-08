namespace svietnamAPI.Repositories.Implements.Auth
{
    public static class UserDbQuery
    {
        public const string GetN_Basic =
        @"SELECT * FROM Users;";
        public const string Get1_ById_Basic =
        @"SELECT * FROM Users WHERE UserId=@UserId";
        public const string Get1_ById_Group =
        @"SELECT * FROM Users use1
        JOIN Groups gro ON gro.GroupId = use1.GroupId
        WHERE UserId=@UserId;";
        public const string Get1_ByUsername_Group =
        @"SELECT * FROM Users use1
        JOIN Groups gro ON gro.GroupId = use1.GroupId
        WHERE Username=@Username;";


    }
}