using System;
using System.Threading.Tasks;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;
using svietnamAPI.Services.Interfaces.AppFile;
using svietnamAPI.Services.Interfaces.Catalog;

namespace svietnamAPI.Services.Interfaces
{
    public interface IServiceWrapper
    {
        ICategoryService CategoryService { get; }
        IAppFileService AppFileService { get; }
        ILoginTokenService LoginTokenService { get; }
        IEntityPermissionService EntityPermissionService { get; }
        IUserService UserService { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }
        // { get; }


    }
}