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
using Discord;
using Discord.WebSocket;

namespace WFRPManagerBot.Core
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            await Context.Channel.SendMessageAsync(CommandsStrings.Help);
        }
    }

    [Group("session")]
    public class GroupCommands : ModuleBase<SocketCommandContext>
    {
        [Command("signup")]
        public async Task Signup()
        {
            if(SessionInfo.activeSignups.ContainsKey(Context.User))
            {
                await Context.Channel.SendMessageAsync("signup user in activesession placeholder");
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.Title = string.Format("{0} {1}", Context.User.Username, CommandsStrings.WantsToStart);

                var message = await Context.Channel.SendMessageAsync("", false, embed.Build());
                await message.AddReactionAsync(new Emoji("✅"));

                SessionInfo.activeSignups.Add(Context.User, message);
            }
        }

        [Command("start")]
        public async Task Start()
        {
            if(SessionInfo.activeSignups.ContainsKey(Context.User))
            {
                await SessionInfo.activeSignups[Context.User].GetReactionUsersAsync(new Emoji("✅"), 64).ForEachAsync(userCollection =>
                {
                    if(!userCollection.Contains(Context.User))
                        Context.User.SendMessageAsync("dm placeholder");

                    foreach (var user in userCollection)
                    {
                        if (!user.IsBot)
                            user.SendMessageAsync("dm placeholder");
                    }
                });
                SessionInfo.activeSignups.Remove(Context.User);
            }
            else
            {
                await Context.Channel.SendMessageAsync("user doesnt hvae a signup started placeholder");
            }
        }
    }
}
