using System.Reflection;

namespace Appointments.Shared.Attributes
{
	public static partial class AttributeExtension
	{


		public static bool GetShowInfo(this PropertyInfo info)
		{
			if (!Attribute.IsDefined(info, typeof(NotShowAttribute)))
			{
				return true;
			}
			return false;

		}

		public static bool GetFilterableInfo(this PropertyInfo info)
		{
			if (!Attribute.IsDefined(info, typeof(NotFilterableAttribute)))
			{
				return true;
			}
			return false;

		}
	}
}
