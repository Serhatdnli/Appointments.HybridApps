
using Newtonsoft.Json;
using System.Xml;

namespace ConsoleApp1
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
