using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

using System.Threading.Tasks;
using Job_test_task_Announcements_Api.Models;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetByIdController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetOne(string id)
        {
            
            var data = Queries.GetElementById(id).Result;
            JsonSerializer.Serialize(data);
            return Ok(data);


        }
    }
}
