using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Discounts;

public class NonHolidayDiscount : BaseEntity<int>
{
    [Column("DayOfWeek")]
    public string dayOfWeek { get; set; }// This will be string since we can add one discount for many days (values will be comma separated)
    [Column("NumberPlateCondition")]
    public string numberPlateCondition { get; set; }// EVEN or ODD
    [Column("Discount")]
    public decimal discount { get; set; } //Discount value is in percentage
}
