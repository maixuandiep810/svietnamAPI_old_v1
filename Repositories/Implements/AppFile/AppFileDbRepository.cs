using System.Net.Mime;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.AppFile;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Dtos.AppFile;

namespace svietnamAPI.Repositories.Implements.AppFile
{
    public partial class AppFileDbRepository : GenericDbRepository, IAppFileDbRepository
    {
        public AppFileDbRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {
        }


    }
}