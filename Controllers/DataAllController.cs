using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Job_test_task_Announcements_Api.Models;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataAllController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllData(string order_by, bool reverse)
        {
            List<Announcement> data = new();
            await DbCreation.Creating_Db();
            StringBuilder dat = new("");
            if (order_by == "price")
            {

                data = Queries.Get_Data("price", reverse, DbCreation.Connection()).Result;
                
            }
            else if (order_by == "date")
            {
                data = Queries.Get_Data("date", reverse, DbCreation.Connection()).Result;
            }
            else { data = Queries.Get_Data("", reverse, DbCreation.Connection()).Result; }
            

            foreach(var i in data)
            {
                dat.Append(JsonSerializer.Serialize(i));
            }
            return Ok(dat.ToString());


        }
    }
}
