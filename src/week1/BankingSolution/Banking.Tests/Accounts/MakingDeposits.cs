using Banking.Domain;

namespace Banking.Tests.Accounts;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesBalance()
    {
        //given 
        var account = new Account(); // balance =5000
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.10M;

        //when 
        account.Deposit(amountToDeposit);

        //then
        var newBalance = account.GetBalance();

        Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());
    }
}
