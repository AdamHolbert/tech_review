using MediatR;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Data;
using StargateAPI.Business.Dtos;
using StargateAPI.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StargateAPI.Business.Queries
{
    public class GetAstronautDutiesByName : IRequest<GetAstronautDutiesByNameResult>
    {
        public string Name { get; set; } = string.Empty;
    }

    public class GetAstronautDutiesByNameHandler : IRequestHandler<GetAstronautDutiesByName, GetAstronautDutiesByNameResult>
    {
        private readonly StargateContext _context;

        public GetAstronautDutiesByNameHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetAstronautDutiesByNameResult> Handle(GetAstronautDutiesByName request, CancellationToken cancellationToken)
        {
            var result = new GetAstronautDutiesByNameResult();

            var person = await _context.People.AsNoTracking().FirstOrDefaultAsync(z => z.Name == request.Name, cancellationToken);

            if (person == null)
                return new GetAstronautDutiesByNameResult { Success = false, Message = "User not found." };

            result.Person = new PersonAstronaut(person, person.AstronautDetail);

            if (person.AstronautDetail == null)
                return result;
            
            result.AstronautDuties = person.AstronautDuties.OrderByDescending(duty => duty.DutyStartDate).Select(duty => new AstronautDutyDTO(duty)).ToList();

            return result;
        }
    }

    public class GetAstronautDutiesByNameResult : BaseResponse
    {
        public PersonAstronaut? Person { get; set; }
        public List<AstronautDutyDTO> AstronautDuties { get; set; } = new List<AstronautDutyDTO>();
    }
}
