using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;

namespace svietnamAPI.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryDbRepository CategoryRepo { get; }
    }
}