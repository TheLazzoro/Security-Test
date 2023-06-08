
using System.Text.Json;
using System.Text;
using System.Net.Http;
using RestSharp;

public static class Login_DOS
{
    public static void Run()
    {
        int threadCount = 8;

        for (int i = 0; i < threadCount; i++)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                int reqCount = 0;
                while (true)
                {
                    string body = "{\"username\": \"lazzoro\", \"password\": \"ansbfkjgasdga\"}";


                    var client = new RestClient("https://localhost:7268/");
                    // client.Authenticator = new HttpBasicAuthenticator(username, password);
                    var request = new RestRequest("Login");
                    request.AddJsonBody(body, false, ContentType.Json);
                    reqCount++;
                    try
                    {
                        var response = client.Post(request);
                        var content = response.Content; // Raw content as string

                        Console.WriteLine($"{content}\n");
                    }
                    catch (Exception)
                    {
                    }
                    Console.WriteLine(reqCount);
                }
            }));

            thread.Start();
        }
    }
}