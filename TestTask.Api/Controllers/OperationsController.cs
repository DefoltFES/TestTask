using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Api.Models;

namespace TestTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        [HttpPost]
        public string CreateOperation(Operation request )
        {
            return request.SumOperation.ToString();
        }
    }
}
