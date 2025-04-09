using PsyPortrait.Bot.Entities;
using PsyPortrait.Bot.Features;
using Telegram.Bot;
using Telegram.Bot.Types;

var builder = WebApplication.CreateBuilder(args);
var token = builder.Configuration["BotToken"]!;             // set your bot token in appsettings.json
var webhookUrl = builder.Configuration["BotWebhookUrl"]!;   // set your bot webhook public url in appsettings.json

builder.Services.AddScoped<TelegramBotHandler>();
builder.Services.ConfigureTelegramBot<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt => opt.SerializerOptions);
builder.Services.AddHttpClient("tgwebhook").RemoveAllLoggers().AddTypedClient(httpClient => new TelegramBotClient(token, httpClient));
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/bot/setWebhook", async (TelegramBotClient bot) => { await bot.SetWebhook(webhookUrl); return $"Webhook set to {webhookUrl}"; });
app.MapPost("/", OnUpdate);
app.Run();

async void OnUpdate(TelegramBotClient bot, Update update, TelegramBotHandler handler)
{
    await handler.HandleUpdateAsync(bot, update);
}
