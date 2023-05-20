using Domain.Entities.Interchanges;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Toll;

public class TollHistory : BaseEntity<int>
{
    [ForeignKey("Interchange")]
    [Column("InterchangeID")]
    public int interchangeID { get; set; }
    [ForeignKey("Vehicle")]
    [Column("VehicleId")]
    public int vehicleId { get; set; }
    [Column("EntryDate")]
    public DateTime entryDate { get; set; }
    [Column("ExitDate")]
    public DateTime? exitDate { get; set; }
    [Column("DiscountApplied")]
    public decimal? discountApplied { get; set; }
    [Column("BaseRate")]
    public decimal? baseRate { get; set; }
    [Column("PerKMCharge")]
    public decimal? perKMCharge { get; set; }
    [Column("DistanceCovered")]
    public decimal? distanceCovered { get; set; }
    [Column("TotalCharged")]
    public decimal? totalCharged { get; set; }
}
