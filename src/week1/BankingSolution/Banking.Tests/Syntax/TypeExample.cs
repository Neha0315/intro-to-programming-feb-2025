

namespace Banking.Tests.Syntax;
public class TypeExample
{

  [Fact]
  public void TimeStandsStill()
  {
    var currentTime = DateTimeOffset.Now;

    Assert.Equal(DateTimeOffset.Now, currentTime);
  }

    [Fact] 
    public void Demo()
    {
        var dt = new DoesThings();

        var result = dt.Repeater(10);

        Assert.Equal(55, result);
    }
}


public class DoesThings
{
    public int Repeater(uint count)
    {   if (count <= int.MaxValue)
        {
            var c = (int)count;
            return Enumerable.Range(1, c).Sum();
        } else
        {
            // throw an exception?
            return 0;
        }
    }
}
