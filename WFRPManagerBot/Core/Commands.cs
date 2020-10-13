using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace WFRPManagerBot.Core
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            await Context.Channel.SendMessageAsync(commands.Help);
        }
    }
}
