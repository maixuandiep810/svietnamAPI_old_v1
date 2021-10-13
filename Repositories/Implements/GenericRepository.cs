using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements
{
    public abstract class GenericRepository
    {
        protected readonly IDataConnectionFactory _dataConnectionFactory;

        public GenericRepository(IDataConnectionFactory dataConnectionFactory)
        {
            _dataConnectionFactory = dataConnectionFactory;
        }
    }
}