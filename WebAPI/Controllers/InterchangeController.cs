using Application.Common.Models;
using Application.Services.Interchange.Queries;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;

namespace WebAPI.Controllers;

public class InterchangeController : ApiControllerBase
{
    [HttpGet("v1/getInterchange")]
    public async Task<ResponseHelper> Get()
    {
        return await Mediator.Send(new GetInterchangeQuery());
    }

}
