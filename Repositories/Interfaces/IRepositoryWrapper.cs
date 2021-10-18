using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Interfaces.AppFile;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.PhysicalFile;

namespace svietnamAPI.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryDbRepository CategoryDbRepo { get; }
        IPhysicalFileRepository PhysicalFileRepo { get; }
        IAppFileDbRepository AppFileDbRepo { get; }
    }
}