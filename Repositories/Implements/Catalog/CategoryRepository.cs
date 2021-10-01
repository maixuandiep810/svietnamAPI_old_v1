using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Implements.Catalog
{
    public class CategoryRepository : GenericRepository, ICategoryRepository
    {
        public CategoryRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {   
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var query = "SELECT * FROM Category";
            var categories = await GetEntitiesAsync<CategoryDto>(query, null);
            return categories;
        }
    }
}