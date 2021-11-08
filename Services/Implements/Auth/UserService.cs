using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Services.Interfaces.AppFile;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Implements.Auth;
using svietnamAPI.Helper;

namespace svietnamAPI.Services.Implements.AppFile
{
    public partial class UserService : BaseService, IUserService
    {
        public UserService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
            : base(mapper, repositoryWrapper, serviceWrapper)
        {
        }

        public async Task<IEnumerable<UserDto>> GetN_Basic_Async(HttpContextEntityPermission httpEP)
        {
            var users = await _repositoryWrapper.UserDbRepo.GetN_Basic_Async(UserDbQuery.GetN_Basic);
            var viewUsers = _mapper.Map<IEnumerable<UserDto>>(users, opt => opt.Items[InfrasConst.AU_OptItems_HttpContextEntityPermission] = httpEP );
            return viewUsers;
        }

        public async Task<UserDto> Get1_ById_Basic_Async(HttpContextEntityPermission httpEP, int userId)
        {
            var user = await _repositoryWrapper.UserDbRepo.Get1_Basic_Async(UserDbQuery.Get1_ById_Basic, userId: userId);
            var viewUser = _mapper.Map<UserDto>(user, opt => opt.Items[InfrasConst.AU_OptItems_HttpContextEntityPermission] = httpEP );
            return viewUser;
        }

        public async Task<UserDto> Get1_ById_Group_Async(HttpContextEntityPermission httpEP, int userId)
        {
            var user = await _repositoryWrapper.UserDbRepo.Get1_Group_Async(UserDbQuery.Get1_ById_Group, userId: userId);
            var viewUser = _mapper.Map<UserDto>(user, opt => opt.Items[InfrasConst.AU_OptItems_HttpContextEntityPermission] = httpEP );
            return viewUser;
        }

        public async Task<LoggedInUserDto> LoginAsync(HttpContextEntityPermission httpEP, LoginUserDto loginUser)
        {
            var user = await _repositoryWrapper.UserDbRepo.Get1_Group_Async(UserDbQuery.Get1_ByUsername_Group, username: loginUser.Username);
            if (user == null)
                return null;
            var isAuthenticated = PasswordHelper.ValidateUserPasswordInfo(loginUser.Password, Convert.FromHexString(user.Salt), user.HashedPassword);
            if (isAuthenticated == false)
                return null;
            var roles = await _repositoryWrapper.RoleDbRepo.GetN_Basic_Async(RoleDbQuery.GetN_ByUserId_GroupCode_Basic, user.UserId, user.Group.Code);
            user.Roles = roles.ToList();
            var viewUser = _mapper.Map<UserDto>(user, opt => opt.Items[InfrasConst.AU_OptItems_HttpContextEntityPermission] = httpEP );
            var loginToken = await _serviceWrapper.LoginTokenService.CreateLoginTokenAsync(user);
            //
            //
            //
            // var fwshifwadx viewRoles = _mapper.Map<IEnumerable<RoleDto>>(user, opt => opt.Items[InfrasConst.AU_OptItems_PTFs] = permission.PTFs);
            //
            //
            //
            var loggedUser = _mapper.Map<LoggedInUserDto>(viewUser);
            loggedUser.LoginToken = loginToken;
            loggedUser.RoleCodes = roles.ToList().Select(p => p.Code).ToList();
            return loggedUser;
        }


    }
}