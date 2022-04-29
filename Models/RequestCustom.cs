using Microsoft.AspNetCore.Mvc;
namespace Job_test_task_Announcements_Api.Models
{
    public class RequestCustom
    {
        public string Id { get; set; }

        public string Status{ get; set; }
        public string Description { get; set; }
    }
}
