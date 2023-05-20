using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Cities;
namespace Domain.Entities.Interchanges;

public class Interchange:BaseEntity<int>
{
    [Column("Name")]
    public string name{ get; set; }
    [Column("Order")]
    public int order { get; set; }
    [Column("Distance")]
    public decimal distance { get; set; }// Default value is in KM

    [ForeignKey("City")]
    [Column("CityID")]
    public int? cityId { get; set; }
    public virtual City city { get; set; }
}
