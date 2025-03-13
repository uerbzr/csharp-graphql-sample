using workshop.services.calculator;

namespace workshop.tests;

public class Tests
{
    [TestCase(1, 2, 3)]
    [TestCase(3, 3, 6)]
    [TestCase(3, 4, 7)]
    public void TestAdder(int a, int b, int expectedResult)
    {
        ICalculation adder = new CalculationService();
        Assert.That(expectedResult, Is.EqualTo(adder.Add(a, b)));
    }
    [TestCase(new int[] { 1, 2, 3 }, 6)]
    [TestCase(new int[] { 5, 5, 5 }, 15)]
    [TestCase(new int[] { 10, 20, 30 }, 60)]
    public void TestAdderMultipleNumbers(int[] numbers, int expectedResult)
    {
        ICalculation adder = new CalculationService();
        Assert.That(expectedResult, Is.EqualTo(adder.Add(numbers)));
    }
}
