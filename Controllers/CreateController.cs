using Job_test_task_Announcements_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Threading.Tasks;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Delete(string title, string description,
                                                int price, string mainfoto, 
                                                string addfoto1, string addfoto2)
        {
           await Queries.Create(new Announcement(title, description, price, mainfoto, addfoto1, addfoto2, DateTime.Now.ToString()));



            return Ok();
        }
    }
}
