using Application.Common.Mappings;
using Domain.Entities.Interchanges;

namespace Application.DTOs;

public class GetInterchangeDTO : IMapFrom<Interchange>
{
    public string name { get; set; }
    public decimal discount { get; set; }
    public int cityId { get; set; }
    public int order { get; set; }
    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<Interchange, GetInterchangeDTO>();
    }
}
