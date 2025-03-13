using workshop.models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Data
{
    public class Query
    {
        [UseSorting]
        [UseFiltering]
        [UseProjection]
        public async Task<IEnumerable<Calculation>> GetPersonInfo(IRepository<Calculation> repository)
        {
            return await repository.Get();
        }
    }
}
