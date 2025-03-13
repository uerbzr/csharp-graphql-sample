using static System.Runtime.InteropServices.JavaScript.JSType;
using workshop.models;
using workshop.wwwapi.DTO;
using AutoMapper;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Calculation, CalculationResponse>();
            CreateMap<CalculationRequest, Calculation>();

        }
    }
}
