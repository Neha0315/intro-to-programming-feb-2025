

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }


    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ", 45)]

    [InlineData("1\n2", 3)]
    [InlineData("1\n2,3", 6)]


    public void SingleDigit(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }
}
