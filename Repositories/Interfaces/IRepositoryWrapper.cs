using svietnamAPI.Repositories.Interfaces.AppFile;
using svietnamAPI.Repositories.Interfaces.Auth;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.PhysicalFile;

namespace svietnamAPI.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryDbRepository CategoryDbRepo { get; }
        IPhysicalFileRepository PhysicalFileRepo { get; }
        IAppFileDbRepository AppFileDbRepo { get; }
        IUserDbRepository UserDbRepo { get; }
        IEndpointDbRepository EndpointDbRepo { get; }
        ILoginTokenDbRepository LoginTokenDbRepo { get; }
        IEntityPermissionDbRepository EntityPermissionDbRepo { get; }
        IRoleDbRepository RoleDbRepo { get; }


    }
}