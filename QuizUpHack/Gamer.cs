using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using QuizUpHack.Helpers;
using QuizUpHack.Models;
using QuizUpHack.Models.RequestModels;
using QuizUpHack.Models.ResponseModels;
using QuizUpHack.Models.ResponseModels.QuizUpHack;

namespace QuizUpHack
{
    public static class Gamer
    {
        private const string Domain = "https://api-android20.quizup.com/";
        private const string MyId = "1631382521931652492";
        private const string MySession = "eyJfZnJlc2giOmZhbHNlLCJfaWQiOnsiIGIiOiJaall6WldFM01qYzNORGxqWkRkbE1UUTJOV0ZsWXprMk0yWTFPVGt5WWpRPSJ9LCJ1c2VyX2lkIjoiMTYzMTM4MjUyMTkzMTY1MjQ5MiJ9.D1tCuw.VmvTUgisVcB75JXre1-RT1ySqpk";
        private const string MySocketId = "253184.3673466";

        public static Task PlayWithRandomOpponent(string slug = "en-airline-logos")
        {
            var baseAddress = new Uri(Domain);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                cookieContainer.Add(baseAddress, new Cookie("session", MySession));
                var result = client.GetAsync("/collections?locale=en&country=GB&maxEmbeddedTopics=20").Result;
                var collection = result.Content.ReadAsAsync<CollectionResponseModel>().Result;
                var slugList = collection.Collection.Widgets[3].Topics.Select(a => a.Slug).ToList();
                //var slugList = collection.Collection.Widgets.Where(r => r.Topics != null)
                //                    .SelectMany(r => r.Topics.Select(a => a.Slug)).ToList();

                do
                {
                    GameResponseModel gameResponse;
                    var flag = true;
                    var gameRequest = new GameRequestModel()
                    {
                        Notify = true,
                        Rematch = false,
                        SocketId = MySocketId,
                        TopicSlug = slug,
                    };
                    WaitBoard waitBoard;
                    do
                    {
                        Console.WriteLine($"{gameRequest.TopicSlug}");
                        result = client.PostAsJsonAsync("/games", gameRequest).Result;
                        result.EnsureSuccessStatusCode();
                        gameResponse = result.Content.ReadAsAsync<GameResponseModel>().Result;
                        if (gameResponse.Game.Players.Count <= 1)
                        {
                            waitBoard = new WaitBoard(10000);
                            waitBoard.Wait("Not Enough Player. Don't Panic! I will find another one.");

                            // gameRequest.TopicSlug = slugList.OrderBy(r => string.Newstring()).FirstOrDefault() ?? "general-knowledge";
                        }
                        else
                        {
                            flag = false;
                        }
                    } while (flag);

                    var channelName = gameResponse.Game.ChannelName;

                    var waitMillisecond = (int)(gameResponse.Game.Ghost.Answers.Sum(r => r.Value.AnswerTime) * 1000);

                    waitBoard = new WaitBoard(waitMillisecond);
                    waitBoard.Wait($"wait {waitMillisecond / 1000} second for {channelName}");


                    var gameResultRequest = new GameResultRequestModel()
                    {
                        Async = false,
                        ClientClock = waitMillisecond / 100,
                        NetworkError = false,
                        Participants = gameResponse.Game.Players.Keys.ToList(),
                        Rounds = gameResponse.Game.Questions.Select(r => new Round()
                        {
                            QuestionId = r.Id,
                            Answers = new Dictionary<string, Models.Answer>()
                            {
                                {
                                    gameResponse.Game.Players.Keys.FirstOrDefault(b => b != MyId),
                                    gameResponse.Game.Ghost.Answers.FirstOrDefault(b => b.Key == r.Id.ToString()).Value
                                },
                                {
                                    gameResponse.Game.Players.Keys.FirstOrDefault(b => b == MyId),
                                    new Models.Answer()
                                    {
                                        AnswerId = gameResponse.Game.Questions.FirstOrDefault(b => b.Id == r.Id)
                                                       ?.CorrectAnswerId ??"-1",
                                        AnswerTime =
                                            (gameResponse.Game.Questions.FirstOrDefault(b => b.Id == r.Id)?.ReadTime ??
                                             9.9) + 0.1
                                    }
                                }

                            }

                        }).ToList()
                    };

                    result = client.PostAsJsonAsync($"/games/{channelName}", gameResultRequest).Result;
                    result.EnsureSuccessStatusCode();
                    var gameResultResponse = result.Content.ReadAsAsync<GameResultResponseModel>().Result;
                    Console.WriteLine(gameResultResponse.Result.WinnerId == MyId
                        ? $"You Win BITCH! + {gameResultResponse.Result.Xps.FirstOrDefault(r => r.Key == MyId).Value.Total} XP"
                        : "You lose!");

                    waitBoard = new WaitBoard(5 * 1000);
                    waitBoard.Wait($"Let's start again!");
                } while (true);
            }
        }

        public static Task PlaySinglePlayer()
        {
            var baseAddress = new Uri(Domain);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                cookieContainer.Add(baseAddress, new Cookie("session", MySession));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en");
                var result = client.GetAsync("/collections?locale=en&country=GB&maxEmbeddedTopics=20").Result;
                var collection = result.Content.ReadAsAsync<CollectionResponseModel>().Result;
                var slugList = collection.Collection.Widgets[3].Topics.Select(a => a.Slug).ToList();
                //var slugList = collection.Collection.Widgets.Where(r => r.Topics != null)
                //                    .SelectMany(r => r.Topics.Select(a => a.Slug)).ToList();
                WaitBoard waitBoard;
                do
                {
                    var gameRequest = new GameRequestModel()
                    {
                        TopicSlug = "name-the-year",
                    };

                    //https://api-android20.quizup.com/gamemode/sp/games
                    //https://api-android20.quizup.com/gamemode/sp/games/04cb331e-db20-4118-9f62-2cc42ec56e6c/pack?pack=2
                    //https://api-android20.quizup.com/gamemode/sp/games/04cb331e-db20-4118-9f62-2cc42ec56e6c/events/pack_completed

                    Console.WriteLine($"{gameRequest.TopicSlug}");
                    result = client.PostAsJsonAsync("/gamemode/sp/games", gameRequest).Result;
                    var gameResponse = result.Content.ReadAsAsync<SinglePlayerGameResponseModel>().Result;

                    var idOfGame = gameResponse.Game.Id;
                    var waitMillisecond = (int)(gameResponse.QuestionPack.Questions.Sum(r => r.ReadTime) * 1000);

                    waitBoard = new WaitBoard(waitMillisecond);
                    waitBoard.Wait($"wait {waitMillisecond / 1000} second for answers");
                    var count = 1;
                    var random = new Random();
                    var limit = random.Next(2, 15);
                    Console.WriteLine($"My target {(limit * 5) + 1}");

                    do
                    {
                        var packCompletedRequest = new PackCompletedRequestModel()
                        {
                            QuestionPack = count,
                            WildcardPack = count
                        };
                        result = client.PostAsJsonAsync($"/gamemode/sp/games/{idOfGame}/events/pack_completed", packCompletedRequest).Result;
                        count++;
                        result = client.GetAsync($"/gamemode/sp/games/{idOfGame}/pack?pack={count}").Result;

                        waitBoard = new WaitBoard(waitMillisecond + random.Next(1, 2000));
                        waitBoard.Wait($"Pack {count}");
                    } while (count < limit);

                    count--;
                    var packResponse = result.Content.ReadAsAsync<SinglePlayerGameResponseModel>().Result;
                    var wrongAnswerRequest = new PackCompletedRequestModel()
                    {
                        AnswerId = packResponse.QuestionPack.Questions.FirstOrDefault()
                            .Answers.FirstOrDefault(a => a.Id != packResponse.QuestionPack.Questions.FirstOrDefault().CorrectAnswerId).Id.ToString(),
                        FailedQuestionNumber = (count * 5) + 1
                    };
                    result = client.PostAsJsonAsync($"/gamemode/sp/games/{idOfGame}/events/wrong_answer", wrongAnswerRequest).Result;

                    var gameResultResponse = result.Content.ReadAsAsync<SingleGameEndedResponseModel>().Result;
                    Console.WriteLine(gameResultResponse.GameEndedStatus.Game.Xp.Total >= 100
                        ? $"You Win BITCH! + {gameResultResponse.GameEndedStatus.Game.Xp.Total} XP"
                        : "You lose!");
                    Console.WriteLine("Press any key for restart!");
                    Console.ReadLine();
                } while (true);
            }
        }

        public static Task PlayTournament()
        {
            const string tournamentId = "6a8777ce-e43f-482c-a5b7-e36bc8d6251b";
            var baseAddress = new Uri(Domain);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                cookieContainer.Add(baseAddress, new Cookie("session", MySession));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en");
                var result = client.GetAsync("/collections?locale=en&country=GB&maxEmbeddedTopics=20").Result;
                var collection = result.Content.ReadAsAsync<CollectionResponseModel>().Result;
                var slugList = collection.Collection.Widgets[3].Topics.Select(a => a.Slug).ToList();
                //var slugList = collection.Collection.Widgets.Where(r => r.Topics != null)
                //                    .SelectMany(r => r.Topics.Select(a => a.Slug)).ToList();
                WaitBoard waitBoard;
                do
                {
                    var gameRequest = new GameRequestModel()
                    {
                        TopicSlug = "math-easy",
                        TournamentId = tournamentId
                    };

                    Console.WriteLine($"{gameRequest.TopicSlug}");
                    result = client.PostAsJsonAsync("/gamemode/sp/tournament/games?locale=en", gameRequest).Result;
                    var gameResponse = result.Content.ReadAsAsync<TournamentGameResponseModel>().Result;

                    var idOfGame = gameResponse.Game.Id;
                    var waitMillisecond = (int)(gameResponse.QuestionPack.Questions.Sum(r => r.ReadTime) * 1000);

                    waitBoard = new WaitBoard(waitMillisecond);
                    waitBoard.Wait($"wait {waitMillisecond / 1000} second for answers");

                    var count = 1;
                    var random = new Random();
                    var limit = 40;
                    Console.WriteLine($"My target {((limit-1) * 8) + 1}");

                    do
                    {
                        var packCompletedRequest = new PackCompletedRequestModel()
                        {
                            QuestionPack = count - 1,
                            TimeInMillis = waitMillisecond*count + random.Next(1, 2000)
                        };
                        
                        result = client.PostAsJsonAsync($"/gamemode/sp/tournament/games/{idOfGame}/events/pack_completed", packCompletedRequest).Result;
                        count++;
                        result = client.GetAsync($"/gamemode/sp/tournament/games/{idOfGame}/questions?locale=en&pack={count}").Result;

                        waitBoard = new WaitBoard(waitMillisecond + random.Next(1, 2000));
                        waitBoard.Wait($"Pack {count} => {((count-1) * 8) + 1}");

                    } while (count < limit);

                    count--;
                    var wrongAnswerRequest = new PackCompletedRequestModel()
                    {
                        FailedQuestionNumber = (count * 8) + 1,
                        TimeInMillis = waitMillisecond * limit + random.Next(1, 5000)
                    };
                    result = client.PostAsJsonAsync($"/gamemode/sp/tournament/games/{idOfGame}/events/wrong_answer", wrongAnswerRequest).Result;

                    var gameResultResponse = result.Content.ReadAsAsync<TournamentGameEndedResponseModel>().Result;
                    Console.WriteLine(gameResultResponse.GameEndedStatus.Game.Xp.Total >= 100
                        ? $"You Win BITCH! + {gameResultResponse.GameEndedStatus.Game.Xp.Total} XP"
                        : "You lose!");
                    Console.WriteLine("Press any key for restart!");
                    Console.ReadLine();
                } while (true);
            }
        }
        
    }
}
