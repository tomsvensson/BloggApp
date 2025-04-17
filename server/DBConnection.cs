using Blog_WebAPI.Models;
using Microsoft.Data.SqlClient;

namespace Blog_WebAPI
{
    public class DBConnection
    {
        public List<Entry> GetAllEntries()
        {
            List<Entry> entries = new List<Entry>();

            var cmd = GetSqlCommand();

            cmd.CommandText = "SELECT * FROM Entries";

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var entry = new Entry()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    Date = DateTime.Parse(reader["Date"].ToString())
                };
                entries.Add(entry);
            }

            return entries;
        }

        public Entry GetEntryById(int id)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "SELECT * FROM Entries WHERE Id = @id";

            cmd.Parameters.AddWithValue("id", id);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var entry = new Entry()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    Date = DateTime.Parse(reader["Date"].ToString())
                };
                return entry;
            }

            return null;

        }

        public void SaveEntry(Entry entry)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "INSERT INTO Entries (Title, Content, Date) VALUES (@title, @content, @date)";

            cmd.Parameters.AddWithValue("title", entry.Title);
            cmd.Parameters.AddWithValue("content", entry.Content);
            cmd.Parameters.AddWithValue("date", entry.Date);

            cmd.ExecuteNonQuery();
        }

        public void UpdateEntry(int id, Entry entry)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "UPDATE Entries SET Title = @title, Content = @content, Date = @date WHERE Id = @id";

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("title", entry.Title);
            cmd.Parameters.AddWithValue("content", entry.Content);
            cmd.Parameters.AddWithValue("date", entry.Date);

            cmd.ExecuteNonQuery();
        }

        public void DeleteEntryById(int id)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "DELETE FROM Entries WHERE Id = @id";

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        private SqlCommand GetSqlCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Blog DB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = System.Data.CommandType.Text;

            return cmd;
        }
    }
}
