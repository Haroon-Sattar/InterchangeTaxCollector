using Application.Common.Mappings;
using Domain.Entities.Cities;

namespace Application.DTOs;

public class CityDTO : IMapFrom<City>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public void Mapping(MappingProfile profile)
    {
        profile.CreateMap<City, CityDTO>();
    }
}

