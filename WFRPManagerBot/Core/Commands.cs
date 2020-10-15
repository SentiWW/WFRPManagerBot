using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;
using Discord;

namespace WFRPManagerBot.Core
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //  (TODO)  Send help message for all other commands
        [Command("help")]
        public async Task Help()
        {
            await Context.Channel.SendMessageAsync(CommandsStrings.Help);
        }
    }
    
    //  Game session related commands
    [Group("session")]
    public class GroupCommands : ModuleBase<SocketCommandContext>
    {
        //  Creates a signup embed and signs users up based on the reactions the embed gets
        [Command("signup")]
        public async Task Signup()
        {
            //  If user already started a signup, send appropriate message
            if(SessionInfo.activeSignups.ContainsKey(Context.User))
            {
                await Context.Channel.SendMessageAsync(CommandsStrings.SessionSignupStarted);
            }
            else
            {
                //  Build embed
                var embed = new EmbedBuilder();
                embed.Title = string.Format("{0} {1}", Context.User.Username, CommandsStrings.WantsToStart);
                embed.Description = string.Format(CommandsStrings.WantsToStartDescription);

                //  Send embed
                var message = await Context.Channel.SendMessageAsync("", false, embed.Build());
                //  Adds initial reaction
                await message.AddReactionAsync(new Emoji("✅"));

                //  Add user and embed message to collection of active signups
                SessionInfo.activeSignups.Add(Context.User, message);
            }
        }

        //  Sends out direct messages to users who signed up for the session
        [Command("start")]
        public async Task Start()
        {
            //  If user who wants to start the session has an active signup
            if(SessionInfo.activeSignups.ContainsKey(Context.User))
            {
                //  Get all users who reacted with ✅ from signup embed
                await SessionInfo.activeSignups[Context.User].GetReactionUsersAsync(new Emoji("✅"), 64).ForEachAsync(userCollection =>
                {
                    //  Send gamemaster's page to user who started the session
                    Context.User.SendMessageAsync(string.Format("{0} {1}", CommandsStrings.LinkToSessionGameMaster, "gamemaster link placeholder"));
                    
                    foreach (var user in userCollection)
                    {
                        //  If user isn't a bot and isn't the session starter, send players page
                        if (!user.IsBot && user.Id != Context.User.Id)
                            user.SendMessageAsync(string.Format("{0} {1} {2}", CommandsStrings.LinkToSessionPlayer, Context.User, "player link placeholder"));
                    }
                });
                //  Remove this signup from collection of active signups
                SessionInfo.activeSignups.Remove(Context.User);
            }
            //  else send appropriate message
            else
            {
                await Context.Channel.SendMessageAsync(CommandsStrings.SessionSignupNotStarted);
            }
        }
    }
}
