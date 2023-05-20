namespace Application.DTOs;

public class GetRateBreakdownDTO
{
    public decimal baseRate { get; set; }
    public decimal perKMRate { get; set; }
    public decimal subTotal { get; set; }
    public decimal discount { get; set; }
    public decimal toBeCharged { get; set; }
    public string numberPlate { get; set; }

}
