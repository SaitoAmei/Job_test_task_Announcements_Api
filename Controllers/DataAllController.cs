using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Job_test_task_Announcements_Api.Models;
using System.Threading.Tasks;
using System.Net;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataAllController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            await DbCreation.Creating_Db();
            StringBuilder dat = new("");
            var data = Queries.Get_Data(DbCreation.Connection()).Result;
            foreach(var i in data)
            {
                dat.Append(JsonSerializer.Serialize(i));
            }
            return Ok(dat.ToString());


        }
    }
}
