using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Job_test_task_Announcements_Api.Models;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpPost]
        public async  Task<IActionResult> Delete(string id, string title)
        {
            if (id == null || id == "")
            {
                return BadRequest(new RequestCustom() { Id = null, Status = BadRequest().StatusCode.ToString(), Description = "Id field can not be empty !!!" });
            }
            int.Parse(id);
            await Queries.Deleting(id, title);

            return Ok();
        }
    }
}
