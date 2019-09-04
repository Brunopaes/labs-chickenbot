using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleTelegram {
    public class Program {
        public class Resposta {
            public string SessionId;
            public MessageResponse Response;
            public string Texto;
        }

        public static Resposta Msg(string sessionId, string m) {
            IamConfig config = new IamConfig("fwOZ-tCYufbkDd7SA9MABWOZMikIukueTrK4E3FJjj_W");
            AssistantService service = new AssistantService("2019-02-28", config);
            service.SetEndpoint("https://gateway.watsonplatform.net/assistant/api");

            if (string.IsNullOrWhiteSpace(sessionId)) {
                var responseSession = service.CreateSession("42b9eeaa-9800-4c85-8e1f-4f9511ac2536");
                sessionId = responseSession.Result.SessionId;
                m = "";
            }

            var response = service.Message("42b9eeaa-9800-4c85-8e1f-4f9511ac2536", sessionId, new MessageInput() {
                Text = m
            });

            string texto;
            if (response.Result != null &&
                response.Result.Output != null &&
                response.Result.Output.Generic != null &&
                response.Result.Output.Generic.Count > 0 &&
                response.Result.Output.Generic[0] != null) {
                texto = response.Result.Output.Generic[0].Text;
            }
            else {
                texto = "[Nada]";
            }

            return new Resposta() {
                SessionId = sessionId,
                Response = response.Result,
                Texto = texto
            };
        }
 
        private static ITelegramBotClient BotClient;
        private static string SessionId = null;

        static void Main(string[] args) {
            //Resposta resposta = Msg(null, null);
            //resposta = Msg(resposta.sessionId, "Oi!");

            BotClient = new TelegramBotClient("925866062:AAHrfAmLuAThJe0KxeyNVSHD4nn23u8bur4");
            var me = BotClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            Console.WriteLine("Awaiting messages!");

            BotClient.OnMessage += Bot_OnMessage;
            BotClient.StartReceiving();

            for (; ; ) {
                Thread.Sleep(60000);
            }
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
            if (!string.IsNullOrWhiteSpace(e.Message.Text)) {
                Resposta resposta;

                if (SessionId == null) {
                    resposta = Msg(null, null);
                    SessionId = resposta.SessionId;
                }
                else {
                    resposta = Msg(SessionId, e.Message.Text.Trim());
                }

                await BotClient.SendTextMessageAsync(e.Message.Chat, resposta.Texto);
            }
        }
    }
}
