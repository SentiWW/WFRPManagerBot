using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRPManagerBot.Web.Models
{
    public class Session
    {
        public string Name { get; set; }
        public ulong GamemasterId { get; set; }
        public uint NumberOfPlayers { get; set; }

        public Session() { }
    }
}
