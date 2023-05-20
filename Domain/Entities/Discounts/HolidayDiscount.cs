using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Discounts;

public class HolidayDiscount :  BaseEntity<int>
{
    [Column("Name")]
    public string name { get; set; }
    [Column("Holiday")]
    public int holiday{ get; set; }// e.g 23rd 
    [Column("HolidayMonth")]
    public int holidayMonth { get; set; }//e.g March
    [Column("Discount")]
    public decimal discount { get; set; }//Discount value is in percentage


}
