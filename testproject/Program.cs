// See https://aka.ms/new-console-template for more information
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using System.Text.Json;

Console.WriteLine("Hello, World!");
using HttpClient httpClient = new HttpClient();

try
{

    ConsoleKeyInfo a = Console.ReadKey();

    GetAllUserRequest request = new GetAllUserRequest
    {
        Count = 10,
        Index = 0,
        RequesterId = Guid.Empty
    };

    string jsonString = JsonSerializer.Serialize(request);
    var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
    var response = await httpClient.PostAsync("https://localhost:7777/api/User/GetAllUsers", httpContent);

    if (response.IsSuccessStatusCode)
    {
        // Yanıt içeriğini oku
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"JSON Yanıt: {jsonResponse}");

        // JSON'u User listesine çevir
        var users = JsonSerializer.Deserialize<GetAllUsersResponse>(jsonResponse);

        foreach (var user in users.Users)
        {
            Console.WriteLine(user.Name);
        }

    }
    else
    {
        Console.WriteLine("Hata: " + response.ReasonPhrase);
    }
    Console.ReadLine();
}
catch (HttpRequestException httpEx)
{
    Console.WriteLine($"HTTP Hatası: {httpEx.Message}");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Hata: {ex.Message}");
    Console.ReadLine();
}
