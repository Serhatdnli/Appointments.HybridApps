namespace $rootnamespace$
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class $fileinputname$Controller : ControllerBase
	{
		private readonly IMediator mediatR;

		public $fileinputname$Controller(IMediator mediatR)
		{
			this.mediatR = mediatR;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Create$fileinputname$")]
		public async Task<IActionResult> Create$fileinputname$([FromBody] Create$fileinputname$Request create$fileinputname$Request)
		{
			await mediatR.Send(create$fileinputname$Request);
			return Ok();
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("AddRandom$fileinputname$")]
		public async Task<IActionResult> AddRandom$fileinputname$([FromBody] AddRandom$fileinputname$Request create$fileinputname$Request)
		{
			await mediatR.Send(create$fileinputname$Request);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAll$fileinputname$s")]
		public async Task<IActionResult> GetAll$fileinputname$s([FromBody] GetAll$fileinputname$Request getAll$fileinputname$Request)
		{
			var response = await mediatR.Send(getAll$fileinputname$Request);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("GetAll$fileinputname$sByFilter")]
		public async Task<IActionResult> GetAll$fileinputname$sByFilter([FromBody] GetAll$fileinputname$ByFilterRequest getAll$fileinputname$ByFilterRequest)
		{
			var response = await mediatR.Send(getAll$fileinputname$ByFilterRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("Delete$fileinputname$WithTcId")]
		public async Task<IActionResult> Delete$fileinputname$WithTcId([FromBody] Delete$fileinputname$WithTcIdRequest delete$fileinputname$WithTcIdRequest)
		{
			var response = await mediatR.Send(delete$fileinputname$WithTcIdRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Delete$fileinputname$With$fileinputname$Id")]
		public async Task<IActionResult> Delete$fileinputname$With$fileinputname$Id([FromBody] Delete$fileinputname$With$fileinputname$IdRequest delete$fileinputname$With$fileinputname$IdRequest)
		{
			var response = await mediatR.Send(delete$fileinputname$With$fileinputname$IdRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteAll$fileinputname$s")]
		public async Task<IActionResult> DeleteAll$fileinputname$s([FromBody] DeleteAll$fileinputname$Request deleteAll$fileinputname$Request)
		{
			var response = await mediatR.Send(deleteAll$fileinputname$Request);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Update$fileinputname$")]
		public async Task<IActionResult> Update$fileinputname$([FromBody] Update$fileinputname$Request update$fileinputname$Request)
		{
			var response = await mediatR.Send(update$fileinputname$Request);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Get$fileinputname$ById")]
		public async Task<IActionResult> Get$fileinputname$ById([FromBody] Get$fileinputname$ByIdRequest get$fileinputname$ByIdRequest)
		{
			var response = await mediatR.Send(get$fileinputname$ByIdRequest);
			return Ok();
		}
	}
}
