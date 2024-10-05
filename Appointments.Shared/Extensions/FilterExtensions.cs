using Appointments.Shared.Attributes;
using Newtonsoft.Json.Serialization;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;

namespace Appointments.Shared.Extensions
{
	public static class FilterExtensions
	{
		public static bool IsFilterValid<T>(this T t)
		{

			var properties = t.GetType().GetProperties().Where(x => x.GetFilterableInfo());

			foreach (var prop in properties)
			{

				var value = prop.GetValue(t);
				var propertyType = prop.PropertyType;
				var propertyName = prop.Name;

				//Console.WriteLine("PropName : " + propertyName + " value : " + value + " type : " + propertyType);

				switch (Type.GetTypeCode(propertyType))
				{
					case TypeCode.String:
						if (!string.IsNullOrEmpty(value?.ToString()))
						{
							//Console.WriteLine(prop.Name + " değeri " + value + " oldugundan true");
							return true; // Geçerli bir değer bulundu
						}
						break;

					case TypeCode.Int32:

						if (propertyType.IsEnum)
						{
							// Eğer enum değeri 0 değilse true döner
							if (value is Enum enumValue && Convert.ToInt32(enumValue) != 0)
							{

								//Console.WriteLine(prop.Name + " değeri " + value + ",  değeri enumun ilk değeri olmadıgından true");
								return true; // Geçerli bir enum değeri bulundu
							}

						}

						if (value is int intValue && intValue != 0)
						{
							//Console.WriteLine(prop.Name + " değeri " + value + ", 0 a eişt olmadığından true");
							return true; // Geçerli bir int değeri bulundu
						}
						break;
					case TypeCode.DateTime:
						if (value is DateTime dateTimeValue && dateTimeValue != default(DateTime))
						{
							//Console.WriteLine(prop.Name + " değeri " + value + ",  değeri varsayılana eşit olmadıgından true");
							return true; // Geçerli bir DateTime değeri bulundu
						}
						break;


					default:
						//Console.WriteLine("defaulta girdi");


						break;
				}
			}

			return false;
		}

		public static Expression<Func<T, bool>> GetFilterExpression<T>(this T t)
		{
			var properties = t.GetType().GetProperties().Where(x => x.GetFilterableInfo());

			var parameter = Expression.Parameter(typeof(T), "x");
			Expression combinedExpression = null;


			foreach (var prop in properties)
			{
				var value = prop.GetValue(t);
				var propertyType = prop.PropertyType;
				var propertyName = prop.Name;

				Expression propertyExpression = Expression.Property(parameter, prop);

				Expression currentExpression = null;

				switch (Type.GetTypeCode(propertyType))
				{
					case TypeCode.String:
						if (!string.IsNullOrEmpty(value?.ToString()))
						{
							var stringValue = Expression.Constant(value.ToString());
							currentExpression = Expression.Equal(propertyExpression, stringValue);
						}
						break;

					case TypeCode.Int32:
						if (propertyType.IsEnum)
						{
							if (value is Enum enumValue && Convert.ToInt32(enumValue) != 0)
							{
								var enumValueExpr = Expression.Constant(enumValue);
								currentExpression = Expression.Equal(propertyExpression, enumValueExpr);
							}
						}
						else if (value is int intValue && intValue != 0)
						{
							var intValueExpr = Expression.Constant(intValue);
							currentExpression = Expression.Equal(propertyExpression, intValueExpr);
						}
						break;

					case TypeCode.DateTime:
						if (value is DateTime dateTimeValue && dateTimeValue != default(DateTime))
						{
							var dateTimeValueExpr = Expression.Constant(dateTimeValue);
							currentExpression = Expression.Equal(propertyExpression, dateTimeValueExpr);
						}
						break;

					default:
						// Diğer türler için ekleme yapabilirsin
						break;
				}

				// Eğer mevcut ifade varsa, bunu birleştir
				if (currentExpression != null)
				{
					combinedExpression = combinedExpression == null
						? currentExpression
						: Expression.AndAlso(combinedExpression, currentExpression);
				}
			}

			return combinedExpression == null
				? x => true // Eğer hiç bir filtre yoksa tüm kayıtları döner
				: Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
		}
	}
}

