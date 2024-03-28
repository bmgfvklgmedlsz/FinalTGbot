using Microsoft.VisualBasic;
using System.Xml.Xsl;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient("6854779110:AAF8Ll_f-29jxxIap0VHdC3YMO917lcHp-0");

        using CancellationTokenSource cts = new();


        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();


        cts.Cancel();
    }

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await HandleCallBackAsync(botClient, update, cancellationToken);
        await MessageHeandler(botClient, update, cancellationToken);
    }
    static async Task HandleCallBackAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update== null || update.CallbackQuery ==null)
        {
            return;
        }
        string answer = update.CallbackQuery.Data!;
        long chatid = update.CallbackQuery.Message.Chat.Id;
        switch (answer)
        {
            case "1":
                await botClient.SendTextMessageAsync(
                chatId: chatid,
                text: "Мармеладова Юлия Анатольевна, Нарциссова Анастасия Геннадьевна",
                cancellationToken: cancellationToken);
                break;
            case "2":
                await botClient.SendTextMessageAsync(
                chatId: chatid,
                text: "На следующую неделю свободны все окна.Часы работы с 10:00 до 21:00.Записаться можно позвоня на номер администратора.",
                cancellationToken: cancellationToken);
                break;
            case "3":
                await botClient.SendTextMessageAsync(
                chatId: chatid,
                text: "+7(123)1488",
                cancellationToken: cancellationToken);
                break;
            case "4":
                await botClient.SendStickerAsync(
                chatId: chatid,
                sticker: InputFile.FromUri("https://raw.githubusercontent.com/bmgfvklgmedlsz/sticker/main/1.webp"),
                cancellationToken: cancellationToken);
                break;
            case "5":
                 await botClient.SendPhotoAsync(
                 chatId: chatid,
                photo: InputFile.FromUri("https://github.com/bmgfvklgmedlsz/nogti/blob/main/9b8c104993c5b453b0753a62a9d3cbc7.jpg?raw=true"),
                cancellationToken: cancellationToken);
                break;
            case "6":
                    await botClient.SendVideoAsync(
            chatId: chatid,
            video: InputFile.FromUri("https://github.com/bmgfvklgmedlsz/nogti/raw/main/document_5199670588892791905.mp4"),
            supportsStreaming: true,
            cancellationToken: cancellationToken);
                break;
            case "7":
                   await botClient.SendAudioAsync(
         chatId: chatid,
         audio: InputFile.FromUri("https://github.com/bmgfvklgmedlsz/nogti/raw/main/Bluerra-Sai%20Old%20Doll.mp3"),
         cancellationToken: cancellationToken);
                    break;
            case "8":
                     await botClient.SendDocumentAsync(
            chatId: chatid,
            document: InputFile.FromUri("https://github.com/bmgfvklgmedlsz/nogti/raw/main/hsvgif_by_zhekabot.gif.mp4"),
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);
                        break;
            case "9":
                Message pollMessage = await botClient.SendPollAsync(
        chatId: update.CallbackQuery.Message.Chat.Id,
        question: "Шарищь за посхалко?",
        options: new[]
        {
            "1488, типа смешно",
            "Ты норм?"
        },
        cancellationToken: cancellationToken);
                    break;
            case "10":
                Message message = await botClient.SendVenueAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                latitude: 61.77528014230082 ,
                longitude: 1.817446392539451,
                title: "Только не бейте",
                address: "Я не знаю, где это",
                cancellationToken: cancellationToken);
                break;
        }

    }

    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
    static async Task MessageHeandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                {

                    var message = update.Message;
                    var user = message.From;
                    var chat = message.Chat;

                    switch (message.Type)
                    {
                        case MessageType.Text:
                            {
                                if (update.Message.Text == null)
                                {
                                    return;

                                }
                                if (update.Message.Text == "/start")
                                {

                                    InlineKeyboardMarkup inlineKeyboard = new(new[]
                                    {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Наши сотрудники", callbackData: "1"),
                                            InlineKeyboardButton.WithUrl(text: "Вывод работ мастеров", url: "https://www.google.com/search?sca_esv=b7834c396069f319&rlz=1C1GCEU_ruRU1074RU1075&sxsrf=ACQVn0_QYaeR006C0sr6wRLmZkg8TWg6vA:1711529680736&q=%D1%81%D1%82%D1%80%D0%B8%D0%B6%D0%BA%D0%B8&tbm=isch&source=lnms&prmd=isvnmbt&sa=X&ved=2ahUKEwjb45H1iJSFAxVRJxAIHV_yA60Q0pQJegQIEhAB&biw=1920&bih=919&dpr=1"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Записаться", callbackData: "2"),
                                            InlineKeyboardButton.WithCallbackData(text: "Номер администратора", callbackData: "3"),
                                        },
                                        new []
                                        {
                                         InlineKeyboardButton.WithCallbackData(text: "Стикер", callbackData: "4"),
                                         InlineKeyboardButton.WithCallbackData(text: "Картинка", callbackData: "5"),
                                        },
                                          new []
                                        {
                                         InlineKeyboardButton.WithCallbackData(text: "Видео смотреть всем", callbackData: "6"),
                                          InlineKeyboardButton.WithCallbackData(text: "песенка", callbackData: "7"),
                                          },
                                           new []
                                        {
                                         
                                         InlineKeyboardButton.WithCallbackData(text: "День родждения", callbackData: "8"),
                                         InlineKeyboardButton.WithCallbackData(text: "Опрос", callbackData: "9"),
                                           },
                                           new []
                                        {

                                         InlineKeyboardButton.WithCallbackData(text: "Где найти этих гениев", callbackData: "10"),
                                           },
                                        });

                                    Message sentMessage = await botClient.SendTextMessageAsync(
                                        chatId: chat.Id,
                                        text: "Che nado?",
                                        replyMarkup: inlineKeyboard,
                                        cancellationToken: cancellationToken);


                                    return;
                                }
                                return;
                            }
                    }
                    return;
                }


        }
    }

}