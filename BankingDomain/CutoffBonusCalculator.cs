using System;

namespace BankingDomain
{
    public class CutoffBonusCalculator : ICalculateBankAccountBonuses
    {
        IProvideTheCutoffClock _cutoff;

        public CutoffBonusCalculator(IProvideTheCutoffClock cutoff)
        {
            _cutoff = cutoff;
        }

        //public CutoffBonusCalculator()
        //{
        //    _cutoff = new StandardCutoffClock();
        //}

        decimal ICalculateBankAccountBonuses.GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            if (_cutoff.IsBeforeCutoff())
            {
                return amountToDeposit * .10M;
            }
            else
            {
                return 0;
            }
        }

        
    }
}