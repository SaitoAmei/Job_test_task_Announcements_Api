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
        public async Task<IActionResult> GetAllData(string order_by, bool decreasing, int page)
        {   

            try
            {
                List<Announcement> data = new();
                await DbCreation.Creating_Db();
                StringBuilder dat = new("");
                if (order_by == "price")
                {

                    data = Queries.Get_Data("price", decreasing, DbCreation.Connection()).Result;

                }
                else if (order_by == "date")
                {
                    data = Queries.Get_Data("date", decreasing, DbCreation.Connection()).Result;
                }
                else { data = Queries.Get_Data("", decreasing, DbCreation.Connection()).Result; }

                int element = 1;
                foreach (var i in data)
                {
                    if (page != 0)
                    {
                        int min = int.Parse($"{page - 1}{page - 1}");
                        int max = int.Parse($"{page}{page - 1}");
                        if (element >= min && element <= max)
                        {
                            dat.Append(JsonSerializer.Serialize(new { i.Title, i.MainFotoLink, i.Price }));
                            element++;
                        }
                        else { element++; continue; }

                    }
                    else 
                    {
                        dat.Append(JsonSerializer.Serialize(new { i.Title, i.MainFotoLink, i.Price }));
                    }
                   
                    
                    /*dat.Append(JsonSerializer.Serialize(i));*/
                }

                return Ok(dat.ToString()) ;
            }
            catch (Exception ) { return Conflict(); }



        }
    }
}
