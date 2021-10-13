using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using svietnamAPI.Repositories.Interfaces;

namespace svietnamAPI.Controllers
{
    public abstract class SVNBaseController : ControllerBase
    {
        protected readonly IRepositoryWrapper _repositoryWrapper;
        public SVNBaseController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}