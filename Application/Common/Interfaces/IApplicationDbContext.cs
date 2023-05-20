using Domain.Entities.Cities;
using Domain.Entities.Discounts;
using Domain.Entities.Interchanges;
using Domain.Entities.Rate;
using Domain.Entities.Toll;
using Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; }
        DbSet<Interchange> Interchanges{ get; }
        DbSet<Vehicle> Vehicles{ get; }
        DbSet<HolidayDiscount> HolidayDiscounts{ get; }
        DbSet<NonHolidayDiscount> NonHolidayDiscounts { get; }
        DbSet<TollHistory> TollHistory { get; }
        DbSet<TollRate> TollRate { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
