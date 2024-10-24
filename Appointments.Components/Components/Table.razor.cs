﻿using Appointments.Utility;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Components.Components
{
	public partial class Table<T> : ComponentBase
	{
		[Parameter]
		public List<T> ModelList { get; set; }

		[Parameter]
		public EventCallback<T> DeleteMethod { get; set; }

		[Parameter]
		public EventCallback ApplyFilterMethod { get; set; }

		[Parameter]
		public EventCallback<int> GoToPageMethod { get; set; }

		[Parameter]
		public T FilterItem { get; set; }

		[Parameter]
		public int ColumnCount { get; set; }

		[Parameter]
		public bool isUpdateButton { get; set; }

		[Parameter]
		public string UpdatePath { get; set; }

		[Parameter]
		public bool isDeleteButton { get; set; } = false;

		[Parameter]
		public bool isPagination { get; set; } = false;

		[Parameter]
		public int CurrentPage { get; set; } = 0;

		[Parameter]
		public int LastPage { get; set; } = 0;

		[Parameter]
		public bool isFilter { get; set; }


		[Parameter]
		public bool isVisitButton { get; set; }

		[Parameter]
		public string VisitPath { get; set; }

		private bool isOperationArea => isDeleteButton || isUpdateButton || isVisitButton;

	

		protected override void OnParametersSet()
		{
			if (isUpdateButton && string.IsNullOrEmpty(UpdatePath))
			{
				throw new ArgumentException("\n\nUpdateButton görüntülensin istedin ama updatePath değeri girmedin, {örnek : '/admin/updatePersonal'}\n\n");
			}

			if (isDeleteButton && !DeleteMethod.HasDelegate)
			{
				throw new ArgumentException("\n\nDelete butonu ekledin ama deleteMethod parametresini boş geçtin\n\n");
			}
		}

		private void UpdateEnumValue(string propertyName, string selectedValue)
		{
            //Console.WriteLine("Update methodddayım.");
            var enumType = typeof(T).GetProperty(propertyName).PropertyType;
			if (Enum.TryParse(enumType, selectedValue, out var enumValue))
			{
				typeof(T).GetProperty(propertyName).SetValue(FilterItem, enumValue);
				//ObjectWriter.Write(FilterItem);
			}
		}

		private void UpdateProperty(string propertyName, object value)
		{
			var propertyInfo = typeof(T).GetProperty(propertyName);
			
			

			if (propertyInfo != null)
			{
				if (propertyInfo.PropertyType == typeof(DateTime))
				{
					propertyInfo.SetValue(FilterItem, DateTime.MinValue);
				}
				propertyInfo.SetValue(FilterItem, value);
				//ObjectWriter.Write(FilterItem);
			}
		}
	}
}
