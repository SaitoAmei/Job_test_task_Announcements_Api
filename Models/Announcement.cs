using System;

namespace Job_test_task_Announcements_Api.Models
{
    public class Announcement
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string MainPhotoLink { get; set; }

        public string AddPhoto1 { get; set; }
        public string AddPhoto2 { get; set; }
        public DateTime Date { get; set; }


        public Announcement(string title,  string description, int price, string main_foto_link, string add_foto1, string add_foto2, DateTime date )
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.MainPhotoLink = main_foto_link;
            this.AddPhoto1 = add_foto1;
            this.AddPhoto2 = add_foto2;
            this.Date = date;
        }

        public Announcement()
        {
        }
    }





}