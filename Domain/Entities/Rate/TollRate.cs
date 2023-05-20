using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Rate;

public class TollRate : BaseEntity<int>
{
    [Column("BaseRate")]
    public decimal baseRate { get; set; }
    [Column("PerKMRate")]
    public decimal perKMRate { get; set; }
    [Column("WeekendPeakFactor")]
    public decimal WeekendPeakFactor { get; set; }// Will be in %
}
