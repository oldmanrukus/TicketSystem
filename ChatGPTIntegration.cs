using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TicketingSystem
{
    public static class ChatGPTIntegration
    {
        private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";

        // Request payload structure.
        public class ChatGPTRequest
        {
            public string model { get; set; }
            public ChatMessage[] messages { get; set; }
        }

        public class ChatMessage
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        // Response payload structure.
        public class ChatGPTResponse
        {
            public Choice[] choices { get; set; }
        }

        public class Choice
        {
            public ChatMessage message { get; set; }
        }

        public static async Task<string> GetAnalysisAsync(string apiKey, string prompt)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                ChatGPTRequest request = new ChatGPTRequest
                {
                    model = "gpt-3.5-turbo",
                    messages = new ChatMessage[]
                    {
                        new ChatMessage { role = "user", content = prompt }
                    }
                };

                string jsonRequest = JsonConvert.SerializeObject(request);
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                }
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ChatGPTResponse chatResponse = JsonConvert.DeserializeObject<ChatGPTResponse>(jsonResponse);
                return chatResponse.choices[0].message.content;
            }
        }
    }
}
