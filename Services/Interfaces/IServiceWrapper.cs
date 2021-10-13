using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;

namespace svietnamAPI.Services.Interfaces
{
    public class IServiceWrapper
    {
        IRepositoryWrapper RepositoryWrapper { get; }
    }
}