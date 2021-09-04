
using Microsoft.AspNetCore.Mvc;
using AppConfigSettings;

using Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiBaseController : ControllerBase
    {
        public ApiBaseController(AppSettings options, IUnitOfWork unitOfWork)
        {
            this.Options = options;
            this.UnitOfWork = unitOfWork;
        }

        protected AppSettings Options { get; set; }
        protected readonly IUnitOfWork UnitOfWork;
    }
}
