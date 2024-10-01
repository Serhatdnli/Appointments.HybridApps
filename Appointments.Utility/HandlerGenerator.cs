namespace Appointments.Utility
{
	public static class HandlerGenerator
	{


		public static void Generate(string fileName, string namespaceName, string path)
		{
			string[] processTypes = new string[]
			{
				"Create",
				"Delete",
				"GetAll",
				$"GetAll{fileName}ByFilter",
				"Update"
			};


			string GenerateFile(string processType)
			{
				var fileString = $"using Appointments.Application.IRepositories;\r\n" +
				$"using Appointments.Application.MediatR.Requests.{fileName}Requests;\r\n" +
				$"using Appointments.Application.MediatR.Responses.{fileName}Responses;\r\n" +
				$"using MediatR;\r\n\r\n" +
				$"namespace Appointments.Application.MediatR.Handlers.{fileName}Handlers\r\n" +
				"{\r\n\t" +
				$"public class {processType}{fileName}OperationHandler : IRequestHandler<{processType}{fileName}Request, {processType}{fileName}Response>\r\n\t" +
				"{\r\n\t\t" +
				$"private readonly I{fileName}Repository {fileName}Repository;\r\n\r\n\t\t" +
				$"public {processType}{fileName}OperationHandler(I{fileName}Repository {fileName}Repository)\r\n\t\t" +
				"{\r\n\t\t\t" +
				$"this.{fileName}Repository = {fileName}Repository;" +
				"\r\n\t\t" +
				"}\r\n\r\n\t\t" +
				$"public async Task<{processType}{fileName}Response> Handle({processType}{fileName}Request request, CancellationToken cancellationToken)\r\n\t\t" +
				"{\r\n\t\t\t" +
				$"return new {processType}{fileName}Response();\r\n\t\t" +
				"}\r\n\t}\r\n}\r\n";

				return fileString;
			}

			for (int i = 0; i < processTypes.Length; i++)
			{
				var processType = processTypes[i];
				var value = GenerateFile(processType);
				var currentPath = AppDomain.CurrentDomain;

				using (var fileStream = File.Create(currentPath + $"/Generated/{processType}{fileName}OperationHandler.cs"))
				{
					byte[] byteArray = new byte[] { Convert.ToByte(value) };
					fileStream.Write(byteArray, 0, byteArray.Length);
				}
			}



		}
	}
}
