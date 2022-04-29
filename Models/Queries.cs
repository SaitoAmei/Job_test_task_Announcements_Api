using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace Job_test_task_Announcements_Api.Models
{
    public static class Queries
    {
        public static async Task<List<Announcement>> Get_Data(string sort_argument, bool reverse, SqlConnection connection)
        {
            string query = new("");
            if (sort_argument == "price")
            {
                if (reverse)
                {
                    query = "Select * FROM Announcement ORDER BY price DESC";
                }
                else
                {
                    query = "Select * FROM Announcement ORDER BY price  ASC";

                }
            }
            else if (sort_argument =="date") 
            {
                if (reverse)
                {
                    query = "Select * FROM Announcement ORDER BY date DESC";
                }
                else
                {
                    query = "Select * FROM Announcement ORDER BY date  ASC";

                }
            }
            else
            {
                query = "Select * FROM Announcement";
            }
            List<Announcement> Data = new List<Announcement>();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = await  command.ExecuteReaderAsync();
            //if (!reader.HasRows){ DbCreating.Insert_Defolts(connection);}
            //reader.Close();
            //reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Announcement announcement = new()
                    {
                        Id =reader.GetValue(0).ToString(),
                        Title = Convert.ToString(reader.GetValue(1)),
                        Description = reader.GetValue(2).ToString(),
                        Price = int.Parse(reader.GetValue(3).ToString()),
                        MainFotoLink = Convert.ToString(reader.GetValue(4)),
                        AddFoto1 = Convert.ToString(reader.GetValue(5)),
                        AddFoto2 = Convert.ToString(reader.GetValue(6)),
                        Date =Convert.ToDateTime(reader.GetValue(7)) 
                        
                    };
                    Data.Add(announcement);

                }


            }

            finally
            {
                if (!reader.IsClosed) { reader.Close();}
            }

            return Data;
        }



        /*public static async Task Appendance(Announcement value)
        {
            SqlCommand command = new ("INSERT INTO Announcement(title, description, price, mfotolink, addfotolink1, addfotolink2, date )" +
                "VALUES (@title, @description,  @price, @mfotolink, @addfotolink1, @addfotolink2, @date )", DbCreation.Connection());
            command.Parameters.AddWithValue("title", value.Title);
            command.Parameters.AddWithValue("description", value.Description);
            command.Parameters.AddWithValue("price", value.Price);
            command.Parameters.AddWithValue("mfotolink", value.MainFotoLink);
            command.Parameters.AddWithValue("addfotolink1", value.AddFoto1);
            command.Parameters.AddWithValue("addfotolink2", value.AddFoto2);
            command.Parameters.AddWithValue("date", value.Date);
            await command.ExecuteNonQueryAsync();
        }*/

        public static async Task<Announcement> GetElementById(string id)
        {
            
            SqlCommand command = new("SELECT id, title, description, price, mfotolink, addfotolink1, addfotolink2, date FROM Announcement WHERE id = @id", DbCreation.Connection());
            command.Parameters.AddWithValue("id", int.Parse(id));
        
            SqlDataReader reader = await command.ExecuteReaderAsync();
            
            try
            {
                while (reader.Read())
                {
                    Announcement announcement = new()
                    {
                        Id = reader.GetValue(0).ToString(),
                        Title = Convert.ToString(reader.GetValue(1)),
                        Description = reader.GetValue(2).ToString(),
                        Price = Convert.ToInt32(reader.GetValue(3)),
                        MainFotoLink = Convert.ToString(reader.GetValue(4)),
                        AddFoto1 = Convert.ToString(reader.GetValue(5)),
                        AddFoto2 = Convert.ToString(reader.GetValue(6)),
                        Date = Convert.ToDateTime(reader.GetValue(7))
                    };
                    return announcement;


                }
            }
            catch (Exception) { return new Announcement(); }

            return new Announcement() { Title = "Не знайдено!!!" };



            }


        public static async Task<bool> Deleting(string id, string title)
        {
            SqlCommand command = new("DELETE FROM Announcement WHERE id=@id OR title=@title", DbCreation.Connection());
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("title", title);
            
            await command.ExecuteNonQueryAsync();
            return true;
        } 

        public static async Task<bool> Create( Announcement value)
        {
            SqlCommand command  = new("INSERT INTO Announcement " +
                "(title,  description, price, mfotolink, addfotolink1, addfotolink2, date)" +
                " VALUES " +
                "(@title, @description, @price, @mfotolink, @addfotolink1, @addfotolink2, @date)", 
                DbCreation.Connection());

            command.Parameters.AddWithValue("title", value.Title);
            command.Parameters.AddWithValue("description", value.Description);
            command.Parameters.AddWithValue("price", value.Price);
            command.Parameters.AddWithValue("mfotolink", value.MainFotoLink);
            command.Parameters.AddWithValue("addfotolink1", value.AddFoto1);
            command.Parameters.AddWithValue("addfotolink2", value.AddFoto2);
            command.Parameters.AddWithValue("date", value.Date);

            await command.ExecuteNonQueryAsync();



            return true;
        }

        public static async Task<int> GetElementCount()
        {
            try
            {
                int counter = 0;
                SqlCommand command = new("SELECT * FROM Announcement ", DbCreation.Connection());
                SqlDataReader reader = await command.ExecuteReaderAsync();

            try
            {
                while (reader.Read())
                {
                    counter++;
                }
            }
            finally 
            {
                if (!reader.IsClosed) { reader.Close(); }
                
            }

            return counter;
            }
            catch (SqlException) { return 0; }
        }



    }
}
