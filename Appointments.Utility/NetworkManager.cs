﻿using Appointments.Application.Attributes;
using Appointments.Application.MediatR.Requests;
using Appointments.Application.MediatR.Responses;
using Appointments.Domain.Models;
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
                string jsonString = JsonConvert.SerializeObject(request ,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore ,ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
                var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                var uri = request.GetNetworkAddress();




                HttpResponseMessage response;

                try
                {
                    response = await httpClient.PostAsync(baseAdress + uri, httpContent);

                    Console.WriteLine(baseAdress + uri, httpContent);


                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        try
                        {
                            var genericResponse = JsonConvert.DeserializeObject<TResponse>(jsonResponse, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                            return genericResponse;
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"JSON Dönüşüm Hatası: {ex.Message}");
                        }
                    }
                    else
                    {

                        // Hata durumunda detayları yazdır
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Hata Kodu: {(int)response.StatusCode} - {response.ReasonPhrase}");
                        Console.WriteLine($"Yanıt İçeriği: {errorContent}");
                        Console.WriteLine($"İstek URI'si: {baseAdress + uri}");
                        Console.WriteLine($"Gönderilen JSON: {jsonString}");

                    }

                    return null;

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

    }
}
