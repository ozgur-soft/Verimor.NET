﻿using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Verimor {
    public interface IVerimor {
        void SetUsername(string username);
        void SetPassword(string password);
        void Sms(string header, string phone, string message, string sendAt = null, string validFor = null);
    }
    public class Verimor : IVerimor {
        private string Endpoint { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        public Verimor() {
            Endpoint = "http://sms.verimor.com.tr/v2";
        }
        public class Request {
            [JsonPropertyName("username")]
            public string Username { init; get; }
            [JsonPropertyName("password")]
            public string Password { init; get; }
            [JsonPropertyName("source_addr")]
            public string SourceAddr { init; get; }
            [JsonPropertyName("send_at")]
            public string SendAt { init; get; }
            [JsonPropertyName("valid_for")]
            public string ValidFor { init; get; }
            [JsonPropertyName("custom_id")]
            public string CustomId { init; get; }
            [JsonPropertyName("datacoding")]
            public string DataCoding { init; get; }
            [JsonPropertyName("messages")]
            public List<Message> Messages { init; get; }
        }
        public class Message {
            [JsonPropertyName("msg")]
            public string Msg { init; get; }
            [JsonPropertyName("dest")]
            public string Dest { init; get; }
            [JsonPropertyName("id")]
            public string Id { init; get; }
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void Sms(string header, string phone, string message, string sendAt = null, string validFor = null) {
            var http = new HttpClient();
            var data = new Request { };
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + "/send.json") { Content = new StringContent(JsonString(data), Encoding.UTF8, MediaTypeNames.Application.Json) };
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<string>(response.Content.ReadAsStream());
            Console.WriteLine(result);
            return;
        }
        public static string JsonString<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
    }
}