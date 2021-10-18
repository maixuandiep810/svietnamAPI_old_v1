using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Implements.AppFile;
using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Implements.PhysicalFile;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Repositories.Interfaces.AppFile;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.PhysicalFile;

namespace svietnamAPI.Repositories.Implements
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected readonly IDataConnectionFactory _dataConnectionFactory;
        public RepositoryWrapper(IDataConnectionFactory dataConnectionFactory)
        {
            _dataConnectionFactory = dataConnectionFactory;
        }

        private ICategoryDbRepository _categoryDbRepo;
        private IPhysicalFileRepository _physicalFileRepo;
        private IAppFileDbRepository _appFileDbRepo;

        public ICategoryDbRepository CategoryDbRepo
        {
            get
            {
                if (this._categoryDbRepo == null)
                {
                    this._categoryDbRepo = new CategoryDbRepository(_dataConnectionFactory);
                }
                return this._categoryDbRepo;
            }
        }
        public IPhysicalFileRepository PhysicalFileRepo
        {
            get
            {
                if (this._physicalFileRepo == null)
                {
                    this._physicalFileRepo = new PhysicalFileRepository(_dataConnectionFactory);
                }
                return this._physicalFileRepo;
            }
        }
        public IAppFileDbRepository AppFileDbRepo
        {
            get
            {
                if (this._appFileDbRepo == null)
                {
                    this._appFileDbRepo = new AppFileDbRepository(_dataConnectionFactory);
                }
                return this._appFileDbRepo;
            }
        }
    }
}