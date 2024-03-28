using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var client = new TelegramBotClient("7042586132:AAHj27LPiAsILlxyb499BuDcQnaZnP1An_M");
        client.StartReceiving(UpdateHandler, Error); /*метод, который выводит бот*/
        Console.ReadLine();
    }
    private static async Task MessageHeandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
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
                                if (message.Text == null)
                                {
                                    return;

                                }
                                if (message.Text == "/start")
                                {
                                    //создание кнопок в строке
                                    InlineKeyboardMarkup inlineKeyboard = (new[]
                                    {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Инструмент", callbackData: "Инструмент"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Контакты", callbackData: "Контакты"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Адрес", callbackData: "Адрес"),
                                        },
                                        });

                                    Message sentMessage = await botClient.SendTextMessageAsync(
                                        chatId: chat.Id,
                                        text: "Выберите Услугу: ",
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
    private static async Task CallBack(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
     
        
        if (update != null && update.CallbackQuery != null)
        {
            string answer = update.CallbackQuery.Data;
            switch (answer)
            {
                case "Инструмент":
                    {
                        Message message = await botClient.SendPhotoAsync(
                        chatId: update.CallbackQuery.Message.Chat.Id,
                         photo: InputFile.FromUri("https://cdn.vseinstrumenti.ru/images/goods/stroitelnyj-instrument/shurupoverty/9074420/560x504/123404954.jpg"),
                        parseMode: ParseMode.Html,
                         cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(
                         chatId: update.CallbackQuery.Message.Chat.Id,
                         text: "Bosch GSB 18V-90 Solo \n В наличии 2 шт. \n 57 944₽",
                         cancellationToken: cancellationToken);

                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://cdn.vseinstrumenti.ru/images/goods/stroitelnyj-instrument/shurupoverty/1573512/560x504/52731852.jpg"),
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(
                      chatId: update.CallbackQuery.Message.Chat.Id,
                      text: "Makita HP001GD201 \n В наличии 31 шт. \n 60 418₽",
                      cancellationToken: cancellationToken);

                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://cdn.vseinstrumenti.ru/images/goods/stroitelnyj-instrument/shurupoverty/900717/560x504/51511454.jpg"),
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(
                      chatId: update.CallbackQuery.Message.Chat.Id,
                      text: "AEG BSB18BL LI-602C \n В наличии 49 шт. \n 46 737₽",
                      cancellationToken: cancellationToken);

                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://cdn.vseinstrumenti.ru/images/goods/stroitelnyj-instrument/gajkoverty/932451/560x504/51526828.jpg"),
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(
                      chatId: update.CallbackQuery.Message.Chat.Id,
                      text: "Makita DTW1002Z \n В наличии 2 шт. \n 49 502₽",
                      cancellationToken: cancellationToken);

                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://cdn.vseinstrumenti.ru/images/goods/stroitelnyj-instrument/gajkoverty/740419/560x504/51340635.jpg"),
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(
                      chatId: update.CallbackQuery.Message.Chat.Id,
                      text: "DEWALT DCF 899 P2 \n В наличии 4 шт. \n 50 842₽",
                      cancellationToken: cancellationToken);

                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://cdn.vseinstrumenti.ru/images/goods/stroitelnyj-instrument/gajkoverty/4690296/560x504/63922968.jpg"),
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(
                      chatId: update.CallbackQuery.Message.Chat.Id,
                      text: "AEG BSS18MTF12BL-402C \n В наличии  > 100  шт. \n 50 391₽",
                      cancellationToken: cancellationToken);
                    }
                    break;
                case "Контакты":
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "ООО «ВсеИнструменты.ру» \n Номер +7 (495) 647-10-00",
                     cancellationToken: cancellationToken);

                    break;
                case "Адрес":
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Метро Авиамоторная \n 2-й Кабельный проезд, д. 1к1",
                     cancellationToken: cancellationToken);
                    break;

            }


        }
    }

    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }
    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await CallBack(botClient, update, cancellationToken);
        await MessageHeandler(botClient, update, cancellationToken);

    }
}