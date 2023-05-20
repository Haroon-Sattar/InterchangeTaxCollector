using Application.DTOs;
using Application.Services.Cities.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

//[Authorize]
public class CityController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CityDTO>> Get()
    {
        return await Mediator.Send(new GetCitiesQuery());
    }
}
