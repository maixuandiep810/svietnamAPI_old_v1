using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Implements.AppFile;
using svietnamAPI.Repositories.Implements.Auth;
using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Implements.PhysicalFile;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Repositories.Interfaces.AppFile;
using svietnamAPI.Repositories.Interfaces.Auth;
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
        private IUserDbRepository _userDbRepo;
        private IEndpointDbRepository _endpointDbRepo;
        private ILoginTokenDbRepository _loginTokenDbRepo;
        private IRoleDbRepository _roleDbRepo;
        private IEntityPermissionDbRepository _entityPermissionDbRepo;


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

        public IUserDbRepository UserDbRepo
        {
            get
            {
                if (this._userDbRepo == null)
                {
                    this._userDbRepo = new UserDbRepository(_dataConnectionFactory);
                }
                return this._userDbRepo;
            }
        }

        public IEndpointDbRepository EndpointDbRepo
        {
            get
            {
                if (this._endpointDbRepo == null)
                {
                    this._endpointDbRepo = new EndpointDbRepository(_dataConnectionFactory);
                }
                return this._endpointDbRepo;
            }
        }
        public ILoginTokenDbRepository LoginTokenDbRepo
        {
            get
            {
                if (this._loginTokenDbRepo == null)
                {
                    this._loginTokenDbRepo = new LoginTokenDbRepository(_dataConnectionFactory);
                }
                return this._loginTokenDbRepo;
            }
        }
        public IEntityPermissionDbRepository EntityPermissionDbRepo
        {
            get
            {
                if (this._entityPermissionDbRepo == null)
                {
                    this._entityPermissionDbRepo = new EntityPermissionDbRepository(_dataConnectionFactory);
                }
                return this._entityPermissionDbRepo;
            }
        }
        public IRoleDbRepository RoleDbRepo
        {
            get
            {
                if (this._roleDbRepo == null)
                {
                    this._roleDbRepo = new RoleDbRepository(_dataConnectionFactory);
                }
                return this._roleDbRepo;
            }
        }


    }
}