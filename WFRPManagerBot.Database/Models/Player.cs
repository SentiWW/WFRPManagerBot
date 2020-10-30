using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRPManagerBot.Web.Models
{
    public class Player
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string Locale { get; set; }

        public Player(ulong Id, string Username, string Locale)
        {
            this.Id = Id;
            this.Username = Username;
            this.Locale = Locale;
        }
    }
}
