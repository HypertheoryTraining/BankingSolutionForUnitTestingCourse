namespace BankingDomain
{
    public interface IProvideTheCutoffClock
    {
        bool IsBeforeCutoff();
    }
}