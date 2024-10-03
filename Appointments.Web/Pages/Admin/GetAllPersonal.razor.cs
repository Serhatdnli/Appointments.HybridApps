using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Application.MediatR.Responses.UserReponses;
using Appointments.Domain.Enums;
using Appointments.Domain.Enums.FilterTypes;
using Appointments.Domain.Models;
using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;
using System.Text.Json;

namespace Appointments.Web.Pages.Admin
{
    public partial class GetAllPersonal : ComponentBase
    {
        private string[] bindingValue = new string[10];
        private Dictionary<UserFilterType, string> UserFilters = new();
        private List<User> Users = new List<User>();
        private bool isFiltered = false;


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
            var request = new GetAllUsersByFilterRequest
            {
                Count = dataPerPage,
                Index = currentPage * dataPerPage,
                RequesterId = Guid.Empty,
                Filter = UserFilters
            };

            GetAllUsersByFilterResponse response = await NetworkManager.SendAsync<GetAllUsersByFilterRequest, GetAllUsersByFilterResponse>(request);

            Users = response.Users;
            totalData = response.Count;
            lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;

            return response;
        }


        private async Task<GetAllUsersResponse> GetPersonalByPage()
        {
            var request = new GetAllUsersRequest
            {
                Count = dataPerPage,
                Index = currentPage * dataPerPage,
                RequesterId = Guid.Empty,
            };

            var response = await NetworkManager.SendAsync<GetAllUsersRequest, GetAllUsersResponse>(request);


            Users = response.Users;
            totalData = response.Count;
            lastPage = totalData % dataPerPage == 0 ? totalData / dataPerPage - 1 : totalData / dataPerPage;
            return response;


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

            isFiltered = UserFilters.Keys.Count() > 0;
            await GoToPage(0);
        }


        private async Task ConfirmDelete(User user)
        {
            var confirmed = await jsRuntime.InvokeAsync<bool>("confirm", user.Name + " " + user.Surname + " Kullanıcısını Silmek İstedğinize Emin misiniz?");
            if (confirmed)
            {

                var request = new DeleteUserByIdRequest
                {
                    RequesterId = Guid.Empty,
                    Id = user.Id,
                };

                var response = await NetworkManager.SendAsync<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);

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
                await GetPersonalByPage();
            StateHasChanged();
        }
    }
}
