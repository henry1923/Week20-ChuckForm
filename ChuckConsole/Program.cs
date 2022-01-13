using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ChuckConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = GetJokes();
            Console.WriteLine(message);
            GetJokes();
        }

        public static string GetJokes()
        {
            string url = "https://api.icndb.com/jokes/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Joke joke = JsonConvert.DeserializeObject<Joke>(response);
                Console.WriteLine(joke.type);
                Console.WriteLine(joke.value.joke);
                Console.WriteLine(response);

                return joke.value.joke;

            }
        }
    }
}
