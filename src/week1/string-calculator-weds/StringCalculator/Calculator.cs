
using StringCalculator;

public class Calculator(ILogger _logger, IWebService webService)
{
  public int Add(string numbers)
  {
    if (numbers == "")
    {
      return 0;
    }

    var result = numbers.Split(',', '\n').Select(int.Parse).Sum();

    try
    {
      _logger.Write(result.ToString());

    }
    catch (LoggingException ex)
    {
       webService.NotifyOfLoggingFailure(ex.Message); 
    }

   // webService.NotifyOfLoggingFailure("Jeff Was Here");
    return result;
   
   
  }
}


public class LoggingException : Exception {

  public string Message { get; }
  public LoggingException(string message)
  {
    Message = message;
  }
}


public interface IWebService
{
  void NotifyOfLoggingFailure(string message);
}
