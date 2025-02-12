

using Banking.Domain;

namespace Banking.Tests.Accounts;
public class MakingWithdrawals
{
    [Theory]
    [InlineData(42.23)]
    [InlineData(3.23)]
    [InlineData(5000)] // can take full balance
    [InlineData(5000.01)] // not correct?
   
    public void MakingWithdrawalsDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, 
            account.GetBalance());

    }

    [Fact(Skip = "We'll do this in the morning")]
    public void OverDraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 0.1M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
