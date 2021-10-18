using System.Net.Mime;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.AppFile;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Dtos.AppFile;
using Microsoft.AspNetCore.Http;

namespace svietnamAPI.Repositories.Implements.AppFile
{
    public partial class AppFileDbRepository
    {
        public async Task<int> CreateAppFileAsync(CreateAppFileDto createAppFile)
        {
            var insertedId = await CreateEntityAsync(AppFileQuery.CreateAppFile, createAppFile);
            return insertedId;
        }
    }
}