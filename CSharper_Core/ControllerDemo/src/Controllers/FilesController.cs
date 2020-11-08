using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ControllerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var file = new FileInfo(@"F:\My_GitHubProject\CSharper\CSharper_Core\ControllerDemo\src\Files\File01.txt");
            var fileStream = await Task.Run(() => file.OpenRead());

            return File(fileStream, "application/octet-stream");
        }
    }
}