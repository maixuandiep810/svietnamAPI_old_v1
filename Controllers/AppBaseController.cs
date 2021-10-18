using Microsoft.AspNetCore.Mvc;
using svietnamAPI.Services.Interfaces;

namespace svietnamAPI.Controllers
{
    public abstract class AppBaseController : ControllerBase
    {
        protected readonly IServiceWrapper _serviceWrapper;
        public AppBaseController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
    }
}