using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFRPManagerBot.Web.Data
{
    public class DataManager
    {
        public async Task GetUser(ulong Id)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM users WHERE users.ID LIKE @Id";
            command.Parameters.AddWithValue("@Id", Id);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(command);

            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=wfrpmanager;uid=root;pwd=;"))
            {
                connection.Open();
                var reader = await mySqlDataAdapter.SelectCommand.ExecuteReaderAsync();
            }

            //MySqlConnection cnn = new MySqlConnection("server=localhost;database=wfrpmanager;uid=root;pwd=;");
        }
    }
}
