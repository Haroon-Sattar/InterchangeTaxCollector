using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehicles;

public class Vehicle : BaseEntity<int>
{
    [Column("NumberPlate")]
    public string numberPlate { get; set; }
}
