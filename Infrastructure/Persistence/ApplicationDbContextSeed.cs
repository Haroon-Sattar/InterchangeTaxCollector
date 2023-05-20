using Domain.Entities.Cities;
using Domain.Entities.Discounts;
using Domain.Entities.Interchanges;
using Domain.Entities.Rate;

namespace Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        if (!context.Cities.Any())
        {
            context.Cities.AddRange(new City[]
            {
                new City { Name = "Lahore", Interchange = new Interchange[] {
                new Interchange{name="NS Interchange", order=1, distance=5},
                new Interchange{name="Ph4 Interchange", order=2, distance=10},
                new Interchange{name="Ferozpur Interchange", order=3, distance=17},
                new Interchange{name="Lake City Interchange", order=4, distance=24},
                new Interchange{name="Raiwand Interchange", order=5, distance=29},
                new Interchange{name="Bahria Interchange", order=6, distance=34}
                } },
            });

            await context.SaveChangesAsync();
        }
        if (!context.TollRate.Any())
        {
            context.TollRate.AddRange(new TollRate[]
            {
                new TollRate{ baseRate = 20,perKMRate = 0.2M,WeekendPeakFactor= 1.5M }
            });

            await context.SaveChangesAsync();
        }
        if (!context.HolidayDiscounts.Any())
        {
            context.HolidayDiscounts.AddRange(new HolidayDiscount[]
            {
                new HolidayDiscount{ name="23rd March",holiday = 23,holidayMonth=3,discount=50},
                new HolidayDiscount{ name="14th August",holiday = 14,holidayMonth=8,discount=50},
                new HolidayDiscount{ name="23rd March",holiday = 25,holidayMonth=12,discount=50}

            });

            await context.SaveChangesAsync();
        }
        if (!context.NonHolidayDiscounts.Any())
        {
            context.NonHolidayDiscounts.AddRange(new NonHolidayDiscount[]
            {
                new NonHolidayDiscount{ dayOfWeek="1,3", numberPlateCondition= "EVEN",discount = 10},
                new NonHolidayDiscount{ dayOfWeek="2,4", numberPlateCondition= "ODD",discount = 10},

            });

            await context.SaveChangesAsync();
        }
    }
}
