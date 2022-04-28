
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Job_test_task_Announcements_Api.Models
{
    public static class DbCreation
    {
        private const string Connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\PC\\SOURCE\\REPOS\\JUNE\\APP_DATA\\DATABASE1.MDF;Integrated Security=True";
        public  static SqlConnection Connection()
        {
            SqlConnection connection = new (Connection_string);
            connection.Open();
            return connection;

        }

        public static void Close_Connection(SqlConnection connection) { connection.Close(); }

        public static async Task Creating_Db()
        {
            SqlCommand command = new ("IF OBJECT_ID(N'[dbo].[Announcement]', N'U') IS NULL BEGIN" +
                " CREATE TABLE Announcement (id int IDENTITY(1,1) PRIMARY KEY," +
                " title nvarchar(200) NOT NULL, " +
                "description nvarchar(1000)," +
                "price nvarchar(50) NOT NULL," +
                "mfotolink nvarchar(100) NOT NULL," +
                "addfotolink1 nvarchar(100), " +
                "addfotolink2 nvarchar(100), " +
                "date nvarchar(50)) END;", DbCreation.Connection());
            await command.ExecuteNonQueryAsync();
        }



    }
}
