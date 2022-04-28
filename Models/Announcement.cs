using System;

namespace Job_test_task_Announcements_Api.Models
{
    public class Announcement
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string MainFotoLink { get; set; }

        public string AddFoto1 { get; set; }
        public string AddFoto2 { get; set; }
        public string Date { get; set; }


        public Announcement(string title,  string description, string price, string main_foto_link, string add_foto1, string add_foto2, string date )
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.MainFotoLink = main_foto_link;
            this.AddFoto1 = add_foto1;
            this.AddFoto2 = add_foto2;
            this.Date = date;
        }

        public Announcement()
        {
        }
    }





}