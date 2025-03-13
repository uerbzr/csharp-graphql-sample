using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using workshop.models;
using workshop.services.calculator;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class CalculatorEndpoints
    {
        public static void ConfigureCalculatorEndpoints(this WebApplication app)
        {
            var add = app.MapGroup("/add");
            add.MapGet("/", GetAll);
            add.MapPost("/calculate", Add);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> Add(CalculationService service, IMapper mapper, IRepository<Calculation> repository, CalculationRequest request)
        {
            try
            {
                //use AutoMapper to turn CalculationRequest into Calculation
                var entity = mapper.Map<Calculation>(request);

                //set some extra properties
                entity.Operation = "Add";
                entity.Result = service.Add(entity.FirstNumber, entity.SecondNumber);

                //add to db
                await repository.Insert(entity);
                await repository.Save();

                var result = await repository.Get();
                var response = mapper.Map<List<Calculation>>(result);
                Log.Information("GetAll {@response}", entity);
                return TypedResults.Ok(entity);
            }
            catch (Exception ex)
            {
                Log.Information("GetAll {@ex}", ex);
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IMapper mapper, IRepository<Calculation> repository)
        {
            try
            {
                var result = await repository.Get();
                var response = mapper.Map<List<Calculation>>(result);
                Log.Information("GetAll {@response}", response);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information("GetAll {@ex}", ex);
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
