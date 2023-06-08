
using System.Text.Json;
using System.Text;
using System.Net.Http;
using RestSharp;

public static class RequestThread
{
    public static void Run()
    {

        int i = 0;
        while (true)
        {
            string body = "{\"Title\": \"hi\", \"Content\": \"some text\"}";


            var client = new RestClient("https://localhost:7268/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("ForumThread");
            request.AddJsonBody(body, false, ContentType.Json);
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Imxhenpvcm8iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c2VyIiwiaWQiOiIxIiwiZXhwIjoxNjg2MjI0ODkwfQ.Td_YtijYLEbtgrMp0SaXyRqsk6hCUQbjGT6oenpPTUc");
            var response = client.Post(request);
            var content = response.Content; // Raw content as string


            i++;

            Console.WriteLine($"{content}\n");
            Console.WriteLine(i);
        }
    }
}