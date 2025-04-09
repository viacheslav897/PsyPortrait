using System.Globalization;
using PsyPortrait.Bot.Localization;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PsyPortrait.Bot.Features;

public class TelegramBotHandler 
{
    public async Task HandleUpdateAsync(TelegramBotClient bot, Update update)
    {
        if (update.Message is null) return;			// we want only updates about new Message
        if (update.Message.Text is null) return;	// we want only updates about new Text Message
        var msg = update.Message;
        var date = ParseDate(msg.Text);
        if (date == null)
        {
            await bot.SendMessage(msg.Chat, Strings.WrongDateFormat);
            return;
        }

        var person = new Entities.Person(date.Value);
        // let's echo back received text in the chat
        await bot.SendMessage(msg.Chat, person.Description);
        // await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
    }

    public DateOnly? ParseDate(string dateString)
    {
        string format = "dd.MM.yyyy";
        CultureInfo provider = CultureInfo.InvariantCulture;
        
        try
        {
            return DateOnly.ParseExact(dateString, format, provider);
        }
        catch (FormatException)
        {
            return null;
        }
    }
} 