using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Requests;
using Appointments.Application.MediatR.Responses;
using Newtonsoft.Json;


namespace Appointments.Utility
{
    public static class NetworkManager
    {
        private const string baseAdress = "https://localhost:7777/api/";
        public async static Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TResponse : MediatRBaseResponse where TRequest : MediatRBaseRequest<TResponse>
        {


            using (var httpClient = new HttpClient())
            {
				


				string jsonString = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                var uri = request.GetNetworkAddress();
                var response = await httpClient.PostAsync(baseAdress + uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
					

						var genericResponse = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                        return genericResponse;
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"JSON Dönüşüm Hatası: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Hata: " + response.ReasonPhrase);
                }

                return null;
            }

        }
    }
}
