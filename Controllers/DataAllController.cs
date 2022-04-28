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
using System;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataAllController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllData(string order_by, bool reverse)
        {
            try
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

                Page page = new() { Pag = 1, Elements = 10 };
                foreach (var i in data)
                {
                    if (page.Elements == 10)
                    {
                        dat.Append(JsonSerializer.Serialize(page));
                        page.Pag++;
                        page.Elements = 0;
                    }

                    dat.Append(JsonSerializer.Serialize(new { i.Title, i.MainFotoLink, i.Price }));
                    /*dat.Append(JsonSerializer.Serialize(i));*/
                    page.Elements++;

                }
                return Ok(dat.ToString()) ;
            }
            catch (Exception ) { return Conflict(); }



        }
    }
}
