using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Implements.Catalog
{
    public partial class CategoryDbRepository
    {
        public async Task UpdateCategoyAsync(UpdateCategoryDto updateCategory)
        {
            await UpdateEntityAsync(CategoryQuery.UpdateCategory, updateCategory);
        }

    }
}