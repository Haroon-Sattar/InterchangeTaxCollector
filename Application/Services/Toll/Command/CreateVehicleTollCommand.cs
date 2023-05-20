using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using AutoMapper;
using Common;
using Domain.Entities.Toll;
using Domain.Entities.Vehicles;
using MediatR;

namespace Application.Services.Toll.Command;

public class CreateVehicleTollCommand : CreateVehicleTollDTO, IRequest<ResponseHelper>
{

}

public class CreateVehicleTollCommandHandler : IRequestHandler<CreateVehicleTollCommand, ResponseHelper>
{
    private readonly IApplicationDbContext _context;

    public CreateVehicleTollCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseHelper> Handle(CreateVehicleTollCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tollRate = _context.TollRate.OrderByDescending(x => x).LastOrDefault();

            if (tollRate != null)
            {
                decimal perKMRate = tollRate.perKMRate;
                decimal totalCharge = tollRate.baseRate;
                decimal totalDiscount = 0;

                var vehicle = _context.Vehicles.Where(x => x.numberPlate.ToUpper() == request.numberPlate.ToString().ToUpper()).OrderBy(x => x).LastOrDefault();
                if (vehicle == null)
                {
                    vehicle = new Vehicle
                    {
                        numberPlate = request.numberPlate,
                    };
                    await _context.Vehicles.AddAsync(vehicle, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                var tollHistory = new TollHistory
                {
                    interchangeID = request.interchangeId,
                    vehicleId = vehicle.Id,
                    entryDate = request.entryDate,
                    exitDate = request.exitDate,
                    discountApplied = null,
                    baseRate = tollRate.baseRate,
                    perKMCharge = null,
                    distanceCovered = null,
                    totalCharged = null
                };

                if (request.exitDate != null)
                {
                    tollHistory = _context.TollHistory.Where(x => x.vehicleId == vehicle.Id && x.interchangeID == request.interchangeId).OrderBy(x => x).LastOrDefault();

                    if (tollHistory != null)
                    {
                        var interchange = _context.Interchanges.Where(x => x.Id == tollHistory.interchangeID).OrderByDescending(x => x).LastOrDefault();
                        tollHistory.exitDate = request.exitDate;

                        //Applying Peak Factor based on exit date
                        if (DateTimeHelper.IsWeekEnd((DateTime)tollHistory.exitDate))
                            perKMRate = perKMRate * 1.5M;
                        totalCharge += interchange.distance * perKMRate;

                        //Applying Discount
                        //Here I am assuming that if entryDate is Holiday then Week day discount will not be applied only Holiday discount will be applied.
                        //Also assuming that holiday discount will be based on entry date
                        var HolidayDiscount = _context.HolidayDiscounts.Where(x => x.holiday == tollHistory.entryDate.Day && x.holidayMonth == tollHistory.entryDate.Month).OrderBy(x => x).LastOrDefault();
                        if (HolidayDiscount != null)
                            totalDiscount = (HolidayDiscount.discount / 100) * totalCharge;
                        else //Checking for Week day discounts
                        {
                            var weekDayDiscount = _context.NonHolidayDiscounts.Where(x => x.dayOfWeek.Contains(((int)tollHistory.entryDate.DayOfWeek).ToString())).OrderByDescending(x => x).LastOrDefault();
                            if (weekDayDiscount != null)
                                if (weekDayDiscount.numberPlateCondition == "EVEN" && int.Parse(request.numberPlate.Split('-')[1]) % 2 == 0)
                                    totalDiscount = ((weekDayDiscount.discount / 100) * totalCharge);
                                else if (weekDayDiscount.numberPlateCondition == "ODD" && int.Parse(request.numberPlate.Split('-')[1]) % 2 != 0)
                                    totalDiscount = ((weekDayDiscount.discount / 100) * totalCharge);

                        }

                        totalCharge = totalCharge - totalDiscount;
                        tollHistory.totalCharged = totalCharge;
                        tollHistory.discountApplied = totalDiscount;
                        tollHistory.distanceCovered = interchange.distance;
                        tollHistory.perKMCharge = perKMRate;

                    }
                    else
                        return new ResponseHelper(0, new object(), new ErrorDef(0, "Error", "Entry Date not found against this vehicle", ""));
                }
                else
                    await _context.TollHistory.AddAsync(tollHistory, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                dynamic result;
                if (request.exitDate != null)
                    result = new GetRateBreakdownDTO
                    {
                        baseRate = tollRate.baseRate,
                        perKMRate = perKMRate,
                        subTotal = (Decimal)(tollRate.baseRate + (perKMRate * tollHistory.distanceCovered)),
                        discount = totalDiscount,
                        toBeCharged = totalCharge,
                        numberPlate = request.numberPlate
                    };
                else
                    result = "Entry is successful against " + request.numberPlate;
                return new ResponseHelper(1, result, new ErrorDef(0, "", "", ""));
            }
            else
                return new ResponseHelper(0, new object(), new ErrorDef(0, "Error", "No Rate found to apply", ""));
        }
        catch (Exception ex)
        {
            return new ResponseHelper(0, new object(), new ErrorDef(0, "Error", ex.Message, ""));
        }
    }
}

