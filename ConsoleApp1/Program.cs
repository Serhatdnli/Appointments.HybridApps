using ConsoleApp1;
using System.Reflection;

IEnumerable<MyEntity> list = new List<MyEntity>()
{
    new MyEntity
    {
        Name = "Muhammet",
        Surname = "Boyraz",
        Age = 24,
        CreateDate = new DateTime(2000,06,15),
        Role = Role.Doctor

    },

    new MyEntity
    {
        Name = "Serhat",
        Surname = "Denli",
        Age = 26,
        CreateDate = new DateTime(1998,08,31),
        Role = Role.Admin
    },

    new MyEntity
    {
        Name = "Ahmet",
        Surname = "İlhan",
        Age = 24,
        CreateDate = new DateTime(2000,09,12),
        Role = Role.Admin
    }
};

MyEntity filter = new MyEntity
{
    Age = 24,
    Surname = "Boyraz"
};


foreach (PropertyInfo pinfo in typeof(MyEntity).GetProperties())
{

    if (pinfo.PropertyType == typeof(string))
    {
        //Console.WriteLine(pinfo.Name + " değeri boş");
        Console.WriteLine(pinfo.Name + " değeri bir string");
    }
}



//list.ToJson();
Console.ReadKey();