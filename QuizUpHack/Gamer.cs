using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using QuizUpHack.Helpers;
using QuizUpHack.Models;
using QuizUpHack.Models.RequestModels;
using QuizUpHack.Models.ResponseModels;
using QuizUpHack.Models.ResponseModels.QuizUpHack;

namespace QuizUpHack
{
    public class Gamer
    {
        private const string Domain = "https://api-android20.quizup.com/";
        // for easy development some const values
        private string _myId;
        private const string MySocketId = "252848.8530962";
        private readonly HttpClient Client = new HttpClient();
        public List<string> mySlugs = new List<string>();

        public Gamer(string email, string password)
        {
            Login(email, password);
        }
        public void Login(string email, string password)
        {
            Client.BaseAddress = new Uri("https://api-android20.quizup.com/");
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en");
            LoginRequestModel loginRequest = new LoginRequestModel()
            {
                AppId = "com.quizup.core",
                AppVersion = "4.0.3",

                DeviceType = "HUAWEI CLT-L29",
                InstallUuid = Guid.NewGuid().ToString(),
                Email = email,
                Password = password,
                Platform = "android"
            };
            var result = Client.PostAsJsonAsync("/login", loginRequest).Result;
            result.EnsureSuccessStatusCode();
            var response = result.Content.ReadAsAsync<LoginResponseModel>().Result;
            _myId = response.Player.Id;
            mySlugs.AddRange(response.Player.TopicsFollowing.Select(r=>r.Slug));
        }

        public void PlayWithRandomOpponent(string slug)
        {

            var result = Client.GetAsync("/collections?locale=en&country=GB&maxEmbeddedTopics=20").Result;
            result.EnsureSuccessStatusCode();
            //var collection = result.Content.ReadAsAsync<CollectionResponseModel>().Result;
            //uncomment for get random slugs 
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
                    Console.WriteLine($"{gameRequest.TopicSlug} searching for opponent");
                    result = Client.PostAsJsonAsync("/games", gameRequest).Result;
                    result.EnsureSuccessStatusCode();
                    gameResponse = result.Content.ReadAsAsync<GameResponseModel>().Result;
                    if (gameResponse.Game.Players.Count <= 1)
                    {
                        waitBoard = new WaitBoard(10000);//escape from api rate limit
                        waitBoard.Wait("Not Enough Player. Don't Panic! I will find another one.");
                        //uncommnet if you want to play random slugs
                        // gameRequest.TopicSlug = slugList.OrderBy(r => string.Newstring()).FirstOrDefault() ?? "general-knowledge";
                    }
                    else
                    {
                        flag = false;
                    }
                } while (flag);

                var channelName = gameResponse.Game.ChannelName;
                var waitMillisecond = (int)(gameResponse.Game.Ghost.Answers.Sum(r => r.Value.AnswerTime) * 1000);//Simulate user game

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
                                    gameResponse.Game.Players.Keys.FirstOrDefault(b => b != _myId),
                                    gameResponse.Game.Ghost.Answers.FirstOrDefault(b => b.Key == r.Id.ToString()).Value
                                },
                                {
                                    gameResponse.Game.Players.Keys.FirstOrDefault(b => b == _myId),
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

                result = Client.PostAsJsonAsync($"/games/{channelName}", gameResultRequest).Result;
                result.EnsureSuccessStatusCode();
                var gameResultResponse = result.Content.ReadAsAsync<GameResultResponseModel>().Result;
                Console.WriteLine(gameResultResponse.Result.WinnerId == _myId
                    ? $"You Win! + {gameResultResponse.Result.Xps.FirstOrDefault(r => r.Key == _myId).Value.Total} XP"
                    : "You Lose, weird?!");

                waitBoard = new WaitBoard(5 * 1000);
                waitBoard.Wait($"Let's start again!");
            } while (true);
        }

        public void PlaySinglePlayer(string slug, int correctAnswer)
        {
            var result = Client.GetAsync("/collections?locale=en&country=GB&maxEmbeddedTopics=20").Result;
            result.EnsureSuccessStatusCode();
            //var collection = result.Content.ReadAsAsync<CollectionResponseModel>().Result;
            //var slugList = collection.Collection.Widgets[3].Topics.Select(a => a.Slug).ToList();
            //var slugList = collection.Collection.Widgets.Where(r => r.Topics != null)
            //                    .SelectMany(r => r.Topics.Select(a => a.Slug)).ToList();
            do
            {
                var gameRequest = new GameRequestModel()
                {
                    TopicSlug = slug,
                };

                Console.WriteLine($"{gameRequest.TopicSlug}");
                result = Client.PostAsJsonAsync("/gamemode/sp/games", gameRequest).Result;
                result.EnsureSuccessStatusCode();
                var gameResponse = result.Content.ReadAsAsync<SinglePlayerGameResponseModel>().Result;

                var idOfGame = gameResponse.Game.Id;
                var waitMillisecond = (int)(gameResponse.QuestionPack.Questions.Sum(r => r.ReadTime) * 1000);

                var waitBoard = new WaitBoard(waitMillisecond);
                waitBoard.Wait($"wait {waitMillisecond / 1000} second for answers");

                var random = new Random();
                //var limit = random.Next(2, 15);//How many pack you want to play? random? Every pack has 5 question
                Console.WriteLine($"My target {correctAnswer}");
                var limit = correctAnswer / 5;

                for (var i = 1; i < limit; i++)
                {
                    var packCompletedRequest = new PackCompletedRequestModel()
                    {
                        QuestionPack = i,
                        WildcardPack = i
                    };
                    result = Client.PostAsJsonAsync($"/gamemode/sp/games/{idOfGame}/events/pack_completed", packCompletedRequest).Result;
                    result.EnsureSuccessStatusCode();
                    result = Client.GetAsync($"/gamemode/sp/games/{idOfGame}/pack?pack={i + 1}").Result;
                    result.EnsureSuccessStatusCode();

                    waitBoard = new WaitBoard(waitMillisecond + random.Next(1, 2000));
                    waitBoard.Wait($"Pack {i}");
                }

                //var packResponse = result.Content.ReadAsAsync<SinglePlayerGameResponseModel>().Result;
                var wrongAnswerRequest = new PackCompletedRequestModel()
                {
                    //uncomment if you want to give wrong answer instead of empty answer
                    // AnswerId = packResponse.QuestionPack.Questions.FirstOrDefault().Answers.FirstOrDefault(a => a.Id != packResponse.QuestionPack.Questions.FirstOrDefault().CorrectAnswerId).Id.ToString(),
                    AnswerId = "-1",
                    FailedQuestionNumber = limit
                };
                result = Client.PostAsJsonAsync($"/gamemode/sp/games/{idOfGame}/events/wrong_answer", wrongAnswerRequest).Result;
                result.EnsureSuccessStatusCode();

                var gameResultResponse = result.Content.ReadAsAsync<SingleGameEndedResponseModel>().Result;
                Console.WriteLine(gameResultResponse.GameEndedStatus.Game.Xp.Total >= 100
                    ? $"You Win! + {gameResultResponse.GameEndedStatus.Game.Xp.Total} XP"
                    : "You Lose, weird?!");

                Console.WriteLine("Press any key for restart!");
                Console.ReadLine();
            } while (true);

        }

        public void PlayTournament(string tournamentId, string slug, int correctAnswer)
        {

            do
            {
                var gameRequest = new GameRequestModel()
                {
                    TopicSlug = slug,
                    TournamentId = tournamentId
                };

                Console.WriteLine($"{gameRequest.TopicSlug}");
                var result = Client.PostAsJsonAsync("/gamemode/sp/tournament/games?locale=en", gameRequest).Result;
                result.EnsureSuccessStatusCode();
                var gameResponse = result.Content.ReadAsAsync<TournamentGameResponseModel>().Result;

                var idOfGame = gameResponse.Game.Id;
                var waitMillisecond = (int)(gameResponse.QuestionPack.Questions.Sum(r => r.ReadTime) * 1000);

                var waitBoard = new WaitBoard(waitMillisecond);
                waitBoard.Wait($"wait {waitMillisecond / 1000} second for answers");

                var random = new Random();
                var limit = correctAnswer / 8;
                Console.WriteLine($"My target {limit}");

                for (var i = 1; i < limit; i++)
                {
                    var packCompletedRequest = new PackCompletedRequestModel()
                    {
                        QuestionPack = i - 1,
                        TimeInMillis = waitMillisecond * i + random.Next(1, 2000)
                    };

                    result = Client.PostAsJsonAsync($"/gamemode/sp/tournament/games/{idOfGame}/events/pack_completed", packCompletedRequest).Result;
                    result.EnsureSuccessStatusCode();
                    result = Client.GetAsync($"/gamemode/sp/tournament/games/{idOfGame}/questions?locale=en&pack={i}").Result;
                    result.EnsureSuccessStatusCode();

                    waitBoard = new WaitBoard(waitMillisecond + random.Next(1, 2000));
                    waitBoard.Wait($"Pack {i} => {((i - 1) * 8) + 1}");

                }

                var wrongAnswerRequest = new PackCompletedRequestModel()
                {
                    FailedQuestionNumber = correctAnswer,
                    TimeInMillis = waitMillisecond * limit + random.Next(1, 5000)
                };
                result = Client.PostAsJsonAsync($"/gamemode/sp/tournament/games/{idOfGame}/events/wrong_answer", wrongAnswerRequest).Result;
                result.EnsureSuccessStatusCode();

                var gameResultResponse = result.Content.ReadAsAsync<TournamentGameEndedResponseModel>().Result;
                Console.WriteLine(gameResultResponse.GameEndedStatus.Game.Xp.Total >= 100
                    ? $"You Win! +  {gameResultResponse.GameEndedStatus.Game.Xp.Total} XP"
                    : "You Lose, weird?!");

                Console.WriteLine("Press any key for restart!");
                Console.ReadLine();
            } while (true);
        }
    }
}
