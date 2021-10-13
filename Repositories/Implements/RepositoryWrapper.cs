using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Repositories.Interfaces.Catalog;

namespace svietnamAPI.Repositories.Implements
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected readonly IDataConnectionFactory _dataConnectionFactory;
        public RepositoryWrapper(IDataConnectionFactory dataConnectionFactory)
        {
            _dataConnectionFactory = dataConnectionFactory;
        }

        private ICategoryDbRepository _categoryRepo;

        public ICategoryDbRepository CategoryRepo
        {
            get
            {
                if (this._categoryRepo == null)
                {
                    this._categoryRepo = new CategoryDbRepository(_dataConnectionFactory);
                }
                return this._categoryRepo;
            }
        }
    }
}