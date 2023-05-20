using Application.Common.Models;
using Application.Services.Toll.Command;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;

namespace WebAPI.Controllers;

public class TollController : ApiControllerBase
{
    [HttpPost("v1/VehicleEntry/")]
    public async Task<ResponseHelper> Create(CreateVehicleTollCommand command)
    {
        return await Mediator.Send(command);
    }
}
