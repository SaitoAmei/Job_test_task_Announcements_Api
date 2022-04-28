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
        public async Task<IActionResult> Creation(string title, string description,
                                                int price, string mainfoto, 
                                                string addfoto1, string addfoto2)
        {
            try
            {
                string description_s = description;
                string addfoto1_s = addfoto1;
                string addfoto2_s = addfoto2;

                if (title == null || mainfoto == null) { throw new ArgumentException(); }
                if (description == null || description == "") { description_s = new("Not"); }
                if (addfoto1 == null || addfoto1 == "") {  addfoto1_s = new("Not"); }
                if (addfoto2 == null || addfoto2 == "") { addfoto2_s = new("Not"); }
                if ( title.Length > 200 || description_s.Length > 100 ) { throw new ArgumentException(); }
                await Queries.Create(new Announcement(title, description_s, price, mainfoto, addfoto1_s, addfoto2_s, DateTime.Now));

                return Ok();
            }
            catch (ArgumentException) { return BadRequest(); }
            //catch (ArgumentNullException) { return BadRequest(); }
            //catch (Exception ) { return BadRequest(); }
        }
    }
}
