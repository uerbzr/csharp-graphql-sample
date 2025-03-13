
namespace workshop.services.calculator;

public class CalculationService : ICalculation
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }
}
