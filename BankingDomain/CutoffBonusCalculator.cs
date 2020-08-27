using System;

namespace BankingDomain
{
    public class CutoffBonusCalculator : ICalculateBankAccountBonuses
    {
        decimal ICalculateBankAccountBonuses.GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            if (BeforeCutoff())
            {
                return amountToDeposit * .10M;
            }
            else
            {
                return 0;
            }
        }

        protected virtual bool BeforeCutoff()
        {
            return DateTime.Now.Hour <= 17;
        }
    }
}