using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Services.Interfaces.AppFile
{
    public interface ILoginTokenService : IBaseService
    {
        Task<string> CreateLoginTokenAsync(UserDto user);


    }
}