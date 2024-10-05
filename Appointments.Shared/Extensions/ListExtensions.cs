
using Newtonsoft.Json;

namespace Appointments.Shared.Extensions
{
    public static class ListExtensions
    {
        public static void ToJson<T>(this IEnumerable<T> list)
        {
            var result = JsonConvert.SerializeObject(list);
            Console.WriteLine(result);
            
        }
    }
}
