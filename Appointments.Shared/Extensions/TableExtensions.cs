using Appointments.Shared.Attributes;

namespace Appointments.Shared.Extensions
{
	public static class TableExtensions
	{

		public static List<string> GetHeads<T>(this T t)
		{

			List<string> heads = new List<string>();

			var properties = typeof(T).GetProperties().Where(x => x.GetShowInfo()).ToList();
			heads = properties.Select(x => x.Name).ToList();

			return heads;
		}




		public static List<string> GetFilterable<T>(this T t)
		{



			List<string> filterablePropertieNames = new List<string>();

			var properties = typeof(T).GetProperties().Where(x => x.GetFilterableInfo()).ToList();
			filterablePropertieNames = properties.Select(x => x.Name).ToList();

			return filterablePropertieNames;

		}


	}
}
