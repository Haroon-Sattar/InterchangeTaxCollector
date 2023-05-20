using Domain.Entities.Interchanges;

namespace Domain.Entities.Cities;
public class City: BaseEntity<int>
{
    public string? Name { get; set; }
    public virtual ICollection<Interchange> Interchange{ get; set; }

}
