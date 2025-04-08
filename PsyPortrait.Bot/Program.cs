using PsyPortrait.Bot.Entities;
using PsyPortrait.Bot.Features;
using Telegram.Bot;
using Telegram.Bot.Types;

var builder = WebApplication.CreateBuilder(args);
var token = builder.Configuration["BotToken"]!;             // set your bot token in appsettings.json
var webhookUrl = builder.Configuration["BotWebhookUrl"]!;   // set your bot webhook public url in appsettings.json

builder.Services.ConfigureTelegramBot<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt => opt.SerializerOptions);
builder.Services.AddHttpClient("tgwebhook").RemoveAllLoggers().AddTypedClient(httpClient => new TelegramBotClient(token, httpClient));
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/bot/setWebhook", async (TelegramBotClient bot) => { await bot.SetWebhook(webhookUrl); return $"Webhook set to {webhookUrl}"; });
app.MapPost("/", OnUpdate);
app.Run();

async void OnUpdate(TelegramBotClient bot, Update update)
{
    if (update.Message is null) return;			// we want only updates about new Message
    if (update.Message.Text is null) return;	// we want only updates about new Text Message
    var msg = update.Message;
    var date = DateOnly.Parse(msg.Text);
    var person = new Person(date);
    Console.WriteLine($"Received message '{msg.Text}' in {msg.Chat}");
    // let's echo back received text in the chat
    await bot.SendMessage(msg.Chat, $"Position 1: {person.FirstPosition}");
    await bot.SendMessage(msg.Chat, $"Position 2: {person.SecondPosition}");
    await bot.SendMessage(msg.Chat, $"Position 3: {person.ThirdPosition}");
    await bot.SendMessage(msg.Chat, $"Position 4: {person.FourthPosition}");
    // await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
}
