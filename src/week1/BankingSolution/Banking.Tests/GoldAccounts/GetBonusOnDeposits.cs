using Banking.Domain;

namespace Banking.Tests.GoldAccounts;
public class GetBonusOnDeposits
{

    [Fact]
    public void GetBonus()
    {
        // Given
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var expectedBonus = 20M;
        var expectedNewBalance = openingBalance + amountToDeposit + expectedBonus;

        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(expectedNewBalance, account.GetBalance());
    }
}
