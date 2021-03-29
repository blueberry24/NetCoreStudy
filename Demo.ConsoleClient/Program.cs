using IdentityModel.Client;
using System;
using System.Net.Http;

namespace Demo.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;
            if (disco.IsError)
            {
                Console.WriteLine($"发生错误：{disco.Error}");
            }

            TokenResponse tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "credentials_client",
                ClientSecret = "secret",
                Scope = "client_scope1"
            }).Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine($"发生错误：{disco.Error}");
            }

            Console.WriteLine($"返回的认证数据是：{tokenResponse.Json}");
            Console.WriteLine($"返回的AccessToken：{tokenResponse.AccessToken}");


            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var response = apiClient.GetAsync("http://localhost:5001/api/Identity/getUserClaims").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"返回状态码：{response.StatusCode.ToString()}");
            }
            else
            {
                Console.WriteLine($"返回数据：{response.Content.ReadAsStringAsync().Result}");
            }


            Console.ReadLine();
        }
    }
}
