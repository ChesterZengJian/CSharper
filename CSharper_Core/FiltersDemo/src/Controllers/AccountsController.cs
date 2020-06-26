using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    [Route("index.html")]
    [ApiController]
    //[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    //[CustomExceptionFilter]
    //[CustomActionFilter]
    //[CustomResourceFilter]
    //[CustomResultFilter]
    [CustomActionFilterAsync]
    [CustomResultFilterAsync]
    [CustomResourceFilterAsync]
    public class AccountsController : ControllerBase
    {
        public string Index()
        {
            int i = 1, k = 3, m = i + k, l = m - m;
            //var j = m / l

            //m_logger.LogInformation("This is log info");
            return "Accounts";
        }
    }
}