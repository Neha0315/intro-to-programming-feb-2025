namespace Banking.Domain;

public class Account
{
    private decimal _openingBalance = 5000;
    public void Deposit(decimal amountToDeposit)
    {
        _openingBalance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        // "Slime it"
        return _openingBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        _openingBalance -= amountToWithdraw;
    }
}


