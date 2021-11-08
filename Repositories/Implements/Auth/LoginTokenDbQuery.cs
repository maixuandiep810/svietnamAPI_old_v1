namespace svietnamAPI.Repositories.Implements.Auth
{
    public static class LoginTokenDbQuery
    {
        public const string Get1_ByJwtToken_Basic =
        @"SELECT * FROM LoginToken WHERE JwtToken=@JwtToken;";

        public const string Create1 = 
        @"INSERT INTO LoginToken (JwtToken) VALUES (@JwtToken);
        SELECT CAST(SCOPE_IDENTITY() as int);";


    }
}