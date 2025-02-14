

namespace StringCalculator;
public class CalculatorTests
{
  private Calculator calculator = new Calculator(Substitute.For<ILogger>(), Substitute.For<IWebService>());


  [Fact]
  public void EmptyStringReturnsZero()
  {
    var result = calculator.Add("");
    Assert.Equal(0, result);
  }

  [Theory]
  [InlineData("1", 1)]
  [InlineData("2", 2)]
  [InlineData("3", 3)]
  [InlineData("2080", 2080)]
 

  public void SingleDigit(string numbers, int expected)
  {
    

    var result = calculator.Add(numbers);

    Assert.Equal(expected, result);
  }
  [Theory]
  [InlineData("1,2", 3)]
  [InlineData("10,21", 31)]
  [InlineData("202,120", 322)]
  public void TwoDigits(string numbers, int expected)
  {
   

    var result = calculator.Add(numbers);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("1,2,3", 6)]
 
  public void ArbitraryDigits(string numbers, int expected)
  {
  

    var result = calculator.Add(numbers);

    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("1,2\n3", 6)]

  public void ArbitraryMixedDelimeters(string numbers, int expected)
  {
  

    var result = calculator.Add(numbers);

    Assert.Equal(expected, result);
  }


}
