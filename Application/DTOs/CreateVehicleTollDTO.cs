using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateVehicleTollDTO
{
    public int interchangeId { get; set; }
    [RegularExpression(@"^[A-Z]{3}-\d{3}$", ErrorMessage = "Invalid number plate format")]
    public string numberPlate { get; set; }
    public DateTime entryDate { get; set; }
    public DateTime? exitDate { get; set; }

}
