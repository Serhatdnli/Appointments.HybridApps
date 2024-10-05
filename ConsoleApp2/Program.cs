using Appointments.Domain.Enums;
using Appointments.Domain.Models;
using Appointments.Shared.Attributes;

User user = new User
{
    Id = Guid.Parse("fd7d9a11-8915-4d50-b4de-a7bdd8635c82"),
    Name = "Muhammet",
    Surname = "Boyraz",
    Email = "boyr4z.m@gmail.com",
    CreateDate = new DateTime(2000, 06, 15),
    Password = "boyraz46",
    PhoneNumber = "05366765246",
    Role = UserRoleType.Admin,
    TcId = "25117914842"
};

var properties = typeof(User).GetProperties().Where(x => x.GetShowInfo()).ToList();

foreach (var prop in properties)
{
    Console.WriteLine("pro : " + prop.Name);
}