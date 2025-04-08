using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PsyPortrait.Bot.Features;

public static class TelegramBotEndpoints
{
    public static void MapBotEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", OnUpdate);
    }
    
    public static async void OnUpdate(TelegramBotClient bot, Update update)
    {
        if (update.Message is null) return;			// we want only updates about new Message
        if (update.Message.Text is null) return;	// we want only updates about new Text Message
        var msg = update.Message;
        var date = DateOnly.Parse(msg.Text);
        var person = new Entities.Person(date);
        Console.WriteLine($"Received message '{msg.Text}' in {msg.Chat}");
        // let's echo back received text in the chat
        await bot.SendMessage(msg.Chat, $"Position 1: {person.FirstPosition}");
        await bot.SendMessage(msg.Chat, $"Position 2: {person.SecondPosition}");
        await bot.SendMessage(msg.Chat, $"Position 3: {person.ThirdPosition}");
        await bot.SendMessage(msg.Chat, $"Position 4: {person.FourthPosition}");
        // await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
    }
}
public class TelegramBotHandler
{
    private readonly ITelegramBotClient _botClient;

    public TelegramBotHandler(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task HandleUpdateAsync(Update update)
    {
        if (update.Message is null) return;			// we want only updates about new Message
        if (update.Message.Text is null) return;	// we want only updates about new Text Message
        var msg = update.Message;
        var date = DateOnly.Parse(msg.Text);
        var person = new Entities.Person(date);
        Console.WriteLine($"Received message '{msg.Text}' in {msg.Chat}");
        // let's echo back received text in the chat
        await _botClient.SendMessage(msg.Chat, $"Position 1: {person.FirstPosition}");
        await _botClient.SendMessage(msg.Chat, $"Position 2: {person.SecondPosition}");
        await _botClient.SendMessage(msg.Chat, $"Position 3: {person.ThirdPosition}");
        await _botClient.SendMessage(msg.Chat, $"Position 4: {person.FourthPosition}");
        // await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
    }
} 