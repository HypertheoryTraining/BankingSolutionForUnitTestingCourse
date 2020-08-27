using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class StandardCutoffClock : IProvideTheCutoffClock
    {
        ISystemTime _systemTime;

        public StandardCutoffClock(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        public bool IsBeforeCutoff()
        {
            return _systemTime.GetCurrent().Hour < 17;
        }
    }
}
