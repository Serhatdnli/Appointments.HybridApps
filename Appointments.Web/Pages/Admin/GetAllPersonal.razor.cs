using Appointments.Application.Filters;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;
using System.Text.Json;

namespace Appointments.Web.Pages.Admin
{
    public partial class GetAllPersonal : ComponentBase
    {
        private string[] bindingValue = new string[10];
        private UserFilter UserFilter = new UserFilter();
        private Dictionary<UserFilterType, string> UserFilters = new();
        private List<User> Users = new List<User>();
        private bool isFiltered = false;

        [Inject]
        public IHttpClientFactory _httpClientFactory { get; set; }
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        int currentPage = 0;
        int lastPage = -1;
        int totalData = -1;
        int dataPerPage = 10;
        int curDataOrder = 0;

        private List<UserRoleType> RoleOptions => Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>().ToList();

        protected override async Task OnInitializedAsync()
        {
            await GoToPage(currentPage);
        }

        private async Task<GetAllUsersByFilterResponse> GetPersonalByFilterByPage()
        {
            Console.WriteLine("Kullanıcılar çekiliyor");
            var httpClient = _httpClientFactory.CreateClient();
            var getAllUserByFilterRequest = new GetAllUserByFilterRequest
            {
                Count = dataPerPage,
                Index = currentPage * dataPerPage,
                RequesterId = Guid.Empty,
                userFilter = UserFilters
            };

            string jsonString = JsonSerializer.Serialize(getAllUserByFilterRequest);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7777/api/User/GetAllUsersByFilter", httpContent);

            if (response.IsSuccessStatusCode)
            {
                // Yanıt içeriğini oku
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // JSON'u User listesine çevir
                GetAllUsersByFilterResponse getAllUsersResponse = null;

                try
                {
                    getAllUsersResponse = JsonSerializer.Deserialize<GetAllUsersByFilterResponse>(jsonResponse);
                    Users = getAllUsersResponse.Users;
                    totalData = getAllUsersResponse.Count;
                    lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
                    return getAllUsersResponse;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Dönüşüm Hatası: {ex.Message}");
                }

                //Console.WriteLine("----ISIMLER----");

                //foreach (var user in getAllUsersResponse.Users)
                //{
                //	Console.WriteLine($"User Name: {user.Name}");
                //}
            }
            else
            {
                Console.WriteLine("Hata: " + response.ReasonPhrase);
            }

            //var client = _httpClientFactory.CreateClient(); // HttpClient nesnesi oluşturuluyor
            return null;
        }


        private async Task<GetAllUsersResponse> GetPersonalByPage()
        {
            Console.WriteLine("Kullanıcılar çekiliyor");
            var httpClient = _httpClientFactory.CreateClient();
            var getAllUserRequest = new GetAllUserRequest
            {
                Count = dataPerPage,
                Index = currentPage * dataPerPage,
                RequesterId = Guid.Empty,
            };

            string jsonString = JsonSerializer.Serialize(getAllUserRequest);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7777/api/User/GetAllUsers", httpContent);

            if (response.IsSuccessStatusCode)
            {
                // Yanıt içeriğini oku
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // JSON'u User listesine çevir
                GetAllUsersResponse getAllUsersResponse = null;

                try
                {
                    getAllUsersResponse = JsonSerializer.Deserialize<GetAllUsersResponse>(jsonResponse);
                    Users = getAllUsersResponse.Users;
                    totalData = getAllUsersResponse.Count;
                    lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
                    return getAllUsersResponse;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Dönüşüm Hatası: {ex.Message}");
                }

                //Console.WriteLine("----ISIMLER----");

                //foreach (var user in getAllUsersResponse.Users)
                //{
                //	Console.WriteLine($"User Name: {user.Name}");
                //}
            }
            else
            {
                Console.WriteLine("Hata: " + response.ReasonPhrase);
            }

            //var client = _httpClientFactory.CreateClient(); // HttpClient nesnesi oluşturuluyor
            return null;
        }

        private void BindFilter(UserFilterType filterType, string value)
        {
            Console.WriteLine("CALİSİYO");


            bool isNull = string.IsNullOrEmpty(value) || filterType == UserFilterType.Role && value == "None";
            if (!UserFilters.Any(x => x.Key == filterType))
            {
                if (!isNull)
                    UserFilters.Add(filterType, value);

            }
            else
            {
                UserFilters[filterType] = value;

                if (isNull)
                    UserFilters.Remove(filterType);
            }

        }

        private async Task ApplyFilterAsync()
        {
            //Console.WriteLine($"Name: {UserFilter.Name}");
            //Console.WriteLine($"Surname: {UserFilter.Surname}");
            //Console.WriteLine($"Email: {UserFilter.Email}");
            //Console.WriteLine($"TC ID: {UserFilter.TcId}");
            //Console.WriteLine($"Phone Number: {UserFilter.PhoneNumber}");
            //Console.WriteLine($"Role: {UserFilter.Role}");
            //Console.WriteLine($"Create Date: {UserFilter.CreateDate}");

            if (UserFilters.Keys.Count() > 0)
            {
                isFiltered = true;
            }
            else
            {
                isFiltered = false;
            }

            await GoToPage(0);
        }


        private void DateChanged(string createDate)
        {
            DateTime dateTimeValue;
            if (DateTime.TryParse(createDate, out dateTimeValue))
            {
                UserFilter.CreateDate = dateTimeValue;
            }
            else
            {
                // Hatalı tarih formatı
                Console.WriteLine("Geçersiz tarih formatı.");
            }

        }

        private void OnRoleChanged(string newRole)
        {
            if (Enum.TryParse(typeof(UserRoleType), newRole, out var role))
            {
                UserFilter.Role = (UserRoleType)role;
                Console.WriteLine($"Rol değişti: {newRole}");
            }
        }
        private async Task ConfirmDelete(User user)
        {
            var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", user.Name + " " + user.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
            if (confirmed)
            {
                Console.WriteLine("evete tıkladı. kullanıcı :" + user.Name + " " + user.Surname + "id : " + user.Id);

                var httpClient = _httpClientFactory.CreateClient();
                var deleteUserWithUserIdRequest = new DeleteUserWithUserIdRequest
                {
                    RequesterId = Guid.Empty,
                    Id = user.Id,
                };


                string jsonString = JsonSerializer.Serialize(deleteUserWithUserIdRequest);
                var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:7777/api/User/DeleteUserWithUserId", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    await GoToPage(currentPage);
                }
            }
        }
        private async Task GoToPage(int page)
        {
            if (page > lastPage)
            {
                lastPage = page;
            }
            currentPage = page;
            Console.WriteLine("[BOYRAZ] SAYFAYA GİDİLİYOR, CURRENT PAGE: " + currentPage);
            if (isFiltered)
                await GetPersonalByFilterByPage();
            else
                await GetPersonalByFilterByPage();
            StateHasChanged();
        }
    }
}
public class SelectListItem
{
    public string Value { get; set; }
    public string Text { get; set; }
}