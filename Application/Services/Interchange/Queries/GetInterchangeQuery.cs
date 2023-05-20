using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Services.Interchange.Queries;

public class GetInterchangeQuery : IRequest<ResponseHelper>
{
}
public class GetInterchangeQueryHandler : IRequestHandler<GetInterchangeQuery,ResponseHelper>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInterchangeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseHelper> Handle(GetInterchangeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _context.Interchanges
                .OrderBy(x => x.order)
                 .ProjectToListAsync<GetInterchangeDTO>(_mapper.ConfigurationProvider);

            return new ResponseHelper(1, result, new ErrorDef(0, string.Empty, string.Empty));
        }
        catch(Exception ex)
        {
            return new ResponseHelper(0, new object(), new ErrorDef(0, ex.Message, "Error",""));
        }
    }
}



