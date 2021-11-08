namespace svietnamAPI.Repositories.Implements.Auth
{
    public static class EndpointDbQuery
    {
        public const string Get1_Role =
        @"SELECT * FROM Endpoints end
        JOIN RoleToEndpoints rte ON rte.EndpointId = end.EndpointId 
        JOIN Roles rol ON rol.RoleId = rte.RoleId  
        WHERE end.EndpointId = @EndpointId
        AND end.Code = @EndpointCode  
        AND rol.Code IN @RoleCodes
        ;";
    }
}