using Job_test_task_Announcements_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

using System.Threading.Tasks;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Creation(string title, string description,
                                                int price, string mainfoto, 
                                                string addfoto1, string addfoto2)
        {
            try
            {
                string description_s = description;
                string addfoto1_s = addfoto1;
                string addfoto2_s = addfoto2;

                if (title == null || mainfoto == null || price == 0) { throw new ArgumentNullException(); }
                if (description == null || description == "") { description_s = new("Not"); }
                if (addfoto1 == null || addfoto1 == "") { addfoto1_s = new("Not"); }
                if (addfoto2 == null || addfoto2 == "") { addfoto2_s = new("Not"); }
                if (title.Length > 200 || description_s.Length > 100) { throw new ArgumentException(); }
                await Queries.Create(new Announcement(title, description_s, price, mainfoto, addfoto1_s, addfoto2_s, DateTime.Now));

                return Ok(new RequestCustom() { Id = (Queries.GetElementCount().Result + 1).ToString(), Status = Ok().StatusCode.ToString(), Description = "Success" });
            }
            catch (ArgumentNullException) 
            {
                return BadRequest(JsonSerializer.Serialize(new RequestCustom() { Id = (Queries.GetElementCount().Result + 1).ToString(), Status = BadRequest().StatusCode.ToString(), Description = " Title and MainfotoLink fields can`t be empty !!!" }));
            }
            catch (ArgumentException)
            {
                return BadRequest(JsonSerializer.Serialize(new RequestCustom() { Id = (Queries.GetElementCount().Result + 1).ToString(), Status = BadRequest().StatusCode.ToString(), Description = " Title cant have char len more than 200" +
                    "Description more than 1000 " }));
            }

            catch (Exception) { return BadRequest(JsonSerializer.Serialize(new RequestCustom() { Id = (Queries.GetElementCount().Result + 1).ToString(), Status = BadRequest().StatusCode.ToString(), Description = " Undefined exception !!!" })); }
        }
    }
}
