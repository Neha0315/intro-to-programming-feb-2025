

using Banking.Domain;

namespace Banking.Tests.Accounts;
public class MakingDeposits
{

    [Fact]
    public void MakingADepositIncreasesBalance() 
    {
        // given
        var account = new Account(); // <--- _balance = 5000
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.10M;

        // when
        account.Deposit(amountToDeposit);

        // then

        var newBalance = account.GetBalance();

      

        Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());
        
    }

    [Fact]
    public void CannotDepositNegativeNumbers()
    {
        var account = new Account();

        Assert.Throws<AccountNegativeTransactionAmountException>(() => account.Deposit(-1));
    }
}
