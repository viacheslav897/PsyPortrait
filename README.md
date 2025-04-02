# PsyPortrait Telegram Bot

A Telegram bot built with C# and the Telegram.Bot library.

## Prerequisites

- .NET 9.0 SDK or later
- A Telegram Bot Token (get it from [@BotFather](https://t.me/botfather))

## Setup

1. Clone this repository
2. Navigate to the `PsyPortrait.Bot` directory
3. Open `appsettings.json` and replace `YOUR_BOT_TOKEN_HERE` with your actual Telegram bot token
4. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

## Features

- Basic message echo functionality
- Error handling for API requests
- Asynchronous message processing
- Configuration-based bot token management

## Usage

1. Start a chat with your bot on Telegram
2. Send any text message to the bot
3. The bot will echo back your message

## Development

The project uses the following main dependencies:
- Telegram.Bot (v22.4.4)
- Microsoft.Extensions.Configuration (v9.0.3)
- Microsoft.Extensions.Configuration.Json (v9.0.3)

## Configuration

The bot token is stored in `appsettings.json`. This file is automatically copied to the output directory when building the project.

## License

This project is open source and available under the MIT License. 