using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChildrensGame.Core
{
    public class Engine : IDisposable
    {
        private const string POST_CREATE_GAME =
            @"http://api:6039/api/games";

        private const string POST_SAVE_RESULT_TEMPLATE =
            @"http://api:6039/api/games/{0}/result";

        private const string MIME_TYPE_JSON = "application/json";

        private const string ENTITY = "engine";

        private static Engine instance;

        private readonly HttpClient client;

        private readonly Logger logger;

        private Engine()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MIME_TYPE_JSON));
            logger = Logger.GetInstance();
        }

        /// <summary>
        /// Gets the singleton instance of the game engine
        /// </summary>
        /// <returns>The instance.</returns>
        public static Engine GetInstance()
        {
            if (instance == null)
            {
                instance = new Engine();
            }
            return instance;
        }

        /// <summary>
        /// Creates a game as an asynchronous operation.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation</returns>
        public async Task<Game> CreateGameAsync()
        {
            var taskLoadManifest = client.PostAsync(POST_CREATE_GAME, new StringContent(""));
            logger.Write(ENTITY, "Loading game manifest...");

            var response = await taskLoadManifest;
            var taskParseManifest = response.Content.ReadAsStringAsync();
            logger.Write(ENTITY, "Game manifest loaded");

            var json = await taskParseManifest;
            var manifest = JsonConvert.DeserializeObject<GameManifest>(json);
            return new Game(manifest);
        }

        /// <summary>
        /// Sends game result as an asynchronous operation.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation</returns>
        /// <param name="result">The game result to send</param>
        public async Task SendResultAsync(GameResult result)
        {
            var json = JsonConvert.SerializeObject(result);
            var content = new StringContent(json, Encoding.UTF8, MIME_TYPE_JSON);

            logger.Write(ENTITY, "Sending result...");
            await client.PostAsync(string.Format(POST_SAVE_RESULT_TEMPLATE, result.Id), content);
            logger.Write(ENTITY, "Result sent successfully");
        }

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
        }
    }
}
