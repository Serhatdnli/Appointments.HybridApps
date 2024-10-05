using Appointments.Shared.Attributes;

namespace Appointments.Shared.Extensions
{
	public static class TableExtensions
	{
		public static Dictionary<string, List<string>> headerDictonary = new();
		public static Dictionary<string, List<string>> filterableDictionary = new();

		public static List<string> GetHeads<T>(this T t)
		{


			if (headerDictonary.TryGetValue(t.GetType().Name, out List<string> value)){
                return value;
			}
			else
			{
				List<string> heads = new List<string>();

				var properties = typeof(T).GetProperties().Where(x => x.GetShowInfo()).ToList();
				heads = properties.Select(x => x.Name).ToList();
				//heads.ToJson();
				headerDictonary.Add(t.GetType().Name, heads);
				return heads;
			}
		}

		


		public static List<string> GetFilterable<T>(this T t)
		{


            if (filterableDictionary.TryGetValue(t.GetType().Name, out List<string> value))
			{
				return value;
			}
			else
			{
				List<string> filterablePropertieNames = new List<string>();

				var properties = typeof(T).GetProperties().Where(x => x.GetFilterableInfo()).ToList();
				filterablePropertieNames = properties.Select(x => x.Name).ToList();

				filterableDictionary.Add(t.GetType().Name, filterablePropertieNames);
				return filterablePropertieNames;
			}
		}


	}
}
