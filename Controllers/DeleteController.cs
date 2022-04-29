
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Job_test_task_Announcements_Api.Models;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Delete(string id, string title)
        {
            try {
                if (id == null || id == "")
                {
                    return BadRequest(new RequestCustom() { Id = null, Status = BadRequest().StatusCode.ToString(), Description = "Id field can not be empty !!!" });
                }
                string title_s = new("");
                if (title == null) { title_s = ""; }
                int.Parse(id);
                await Queries.Deleting(id, title_s);

                return Ok(new RequestCustom() { Id = id, Status = Ok().StatusCode.ToString(), Description = "Deleting success !" });
            }
            catch (Exception exception) 
            {
                return BadRequest(new RequestCustom() { Id = null, Status = BadRequest().StatusCode.ToString(), Description = $" Exception :\n {exception.ToString()}" });
            }
            
        }
    }
}
