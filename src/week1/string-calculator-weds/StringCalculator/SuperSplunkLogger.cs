

namespace StringCalculator;
public class SuperSplunkLogger : ILogger
{
  public void Write(string message)
  {
    // do all the stuff to write this to a log file, or whatever.
    File.AppendAllText("mylogfix.txt", message + Environment.NewLine);
  }
}
