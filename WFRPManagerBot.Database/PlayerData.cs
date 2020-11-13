using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFRPManagerBot.Web.Models;

namespace WFRPManagerBot.Database
{
    public static class PlayerData
    {
        public static Player GetPlayer(ulong playerId)
        {
            var player = new Player();

            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["MySqlConnectionString"]))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * " +
                                                       "FROM Players p" +
                                                       "WHERE p.Id = @Id", connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            player.Id = ulong.Parse(reader.GetString(0));
                            player.Locale = reader.GetString(1);
                            player.Username = reader.GetString(2);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return player;
        }

        public static void SetPlayer(Player player)
        {

        }
    }
}
