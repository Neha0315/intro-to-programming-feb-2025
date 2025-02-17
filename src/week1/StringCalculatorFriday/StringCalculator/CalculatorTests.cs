
namespace StringCalculator;
public class CalculatorTests
{
    //Test 1
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    //Test 2
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void SingleDigit(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 3
    [Theory]
    [InlineData("1,2", 3)]
    public void DoubleDigit(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 4
    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ", 45)]
    public void MultiDigit(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 5
    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2,3", 6)]
    public void MixDelimeters(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 6
    [Theory]
    [InlineData("//#\n1#2#3", 6)]
    [InlineData("//#\n1#2,3\n1", 7)]
    public void CustomDelimeters(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 7
    [Theory]
    [InlineData("//#\n1#-2#3", "Negatives not allowed: -2")]
    public void NoNegativeNums(string value, string expectedMessage)
    {
        var calculator = new Calculator();

        var exception = Assert.Throws<ArgumentException>(() => calculator.Add(value));

        Assert.Equal(expectedMessage, exception.Message);
    }

    //Test 8
    [Theory]
    [InlineData("1,-4,5,-6", "Negatives not allowed: -4, -6")]
    public void NegativeNumsListed(string value, string expectedMessage)
    {
        var calculator = new Calculator();

        var exception = Assert.Throws<ArgumentException>(() => calculator.Add(value));

        Assert.Equal(expectedMessage, exception.Message);
    }

    //Test 9
    [Theory]
    [InlineData("2,3,9876", 5)]
    public void NumsBiggerThan1000(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 10
    [Theory]
    [InlineData("//[***]\n1***2", 3)]
    public void CustomDelimitersOfAnyLength(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);

        Assert.Equal(expected, result);
    }

    //Test 11
    [Theory]
    [InlineData("//[***]\n1***2", 3)]
    public void MultipleCustomDelimeters(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expected, result);
    }



}