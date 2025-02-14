

namespace StringCalculator;
public class CalculatorInteractionTests
{
  [Theory]
  [InlineData("1")]
  [InlineData("2")]
  [InlineData("123")]
  public void CallsLoggerWithResult(string numbers)
  {
    var mockedLogger = Substitute.For<ILogger>();
    var mockedWebService = Substitute.For<IWebService>();
    var calculator = new Calculator(mockedLogger, mockedWebService);

    calculator.Add(numbers);

    // Assert??
    mockedLogger.Received(1).Write(numbers);

    mockedWebService.DidNotReceive().NotifyOfLoggingFailure(Arg.Any<string>());
  }

  [Theory]
  [InlineData("1")]
  public void WhenTheLoggerFailsCallAWebServiceToReportIt(string numbers)
  {
    var stubbedLogger = Substitute.For<ILogger>();
    var mockedWebService = Substitute.For<IWebService>();
    var message = Guid.NewGuid().ToString();
    stubbedLogger.When(c => c.Write(Arg.Any<string>()))
     .Throw(new LoggingException(message));
    var calculator = new Calculator(stubbedLogger, mockedWebService);

    calculator.Add(numbers);

    // Assert
    mockedWebService.Received(1).NotifyOfLoggingFailure(message);

  }
}
