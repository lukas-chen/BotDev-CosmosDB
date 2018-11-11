﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application4.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            StateClient stateClient = activity.GetStateClient();
            BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
            MyUserData userprofile = new MyUserData()
            userData.SetProperty<MyUserData>("UserData", userprofile);

            await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);

            BotData userData2 = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);


            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"Hi {dataresult.Name} , You sent {activity.Text} which was {length} characters ");



            // return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
    }
    public class MyUserData

}