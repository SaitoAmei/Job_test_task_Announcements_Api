﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

using System.Threading.Tasks;
using Job_test_task_Announcements_Api.Models;
using System;

namespace Job_test_task_Announcements_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetByIdController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetOne(string id, bool fields)
        {
            if (id == null ||  id == "") 
            { 
                return BadRequest(new RequestCustom() 
                { 
                    Id = null, Status = BadRequest().StatusCode.ToString(), Description = "Id field can not be empty !!!"
                });
            }

            Announcement data = new();
            try
            {
                if (fields)
                {
                    data = Queries.GetElementById(id).Result;
                    JsonSerializer.Serialize(data);
                    return Ok(JsonSerializer.Serialize(data));
                }
                else
                {
                    data = Queries.GetElementById(id).Result;
                    Dictionary<string, object> dict = new() {};
                    dict.Add("Title", data.Title);
                    dict.Add("Price", data.Price);
                    dict.Add("Data", data.Date);
                    return Ok(JsonSerializer.Serialize(dict));
                }
            }
            catch (Exception exception) 
            { 
                return BadRequest(new RequestCustom() { Id = id, Status = BadRequest().StatusCode.ToString(), Description = exception.ToString() }); 
            }




        }
    }
}
