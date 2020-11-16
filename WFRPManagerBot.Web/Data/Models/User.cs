using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFRPManagerBot.Web.Data.Models
{
    public class User
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }

        public User(ulong Id, string Name, string Locale)
        {
            this.Id = Id;
            this.Name = Name;
            this.Locale = Locale;
        }
    }
}
