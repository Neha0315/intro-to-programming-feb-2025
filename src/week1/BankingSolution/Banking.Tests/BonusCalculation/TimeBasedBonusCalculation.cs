using Banking.Domain;

namespace Banking.Tests.BonusCalculation
{
    public class TimeBonusCalculatorTests
    {
        [Theory]
        [InlineData(5000, 100, 20)]
        [InlineData(5000, 200, 40)]
        [InlineData(10_000, 200, 0)]

        public void BonusesThatMeetThresholdGetBonusIfDuringBusinessHours(decimal balance, decimal depositAmount, decimal expectedBonus)
        {
            var bonusCalculator = new TimeBoundBonusCalculator();

            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

            Assert.Equal(expectedBonus, bonus);
        }

        [Theory]
        [InlineData(5, 100, 10)]
        [InlineData(4999.9, 200, 0)]
        [InlineData(0, 1000, 0)]

        public void BonusesThatMeetThresholdGetNoBonusOutsideBusinessHours(decimal balance, decimal depositAmount, decimal expectedBonus)
        {
            var bonusCalculator = new TimeBoundBonusCalculator();

            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

            Assert.Equal(expectedBonus, bonus);
        }
    }
}
