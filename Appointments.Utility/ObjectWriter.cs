using System.Text.Json;
namespace Appointments.Utility
{
	public static class ObjectWriter
	{
		public static void Write(object obj)
		{
			if (obj == null)
			{
				Console.WriteLine("Null object provided.");
				return;
			}

			string json = JsonSerializer.Serialize(obj);
			Console.WriteLine(json);
		}
	}
}
