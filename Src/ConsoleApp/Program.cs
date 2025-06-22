using MoneyLogic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Account = new Account("BE05252255222", "My Account");        
            Account.SetBalance(1000);

            var Operation = new Operation(
                "Revenu",
                3500,
                Periods.NewPeriods(DateOnly.Parse("2025-1-01"), DateOnly.Parse("2026-01-01"),
                PeriodType.monthly), OperationType.Fix);

            var Operation2 = new Operation(
               "NetFlix",
               -20,
               Periods.NewPeriods(DateOnly.Parse("2025-1-01"), DateOnly.Parse("2026-01-01"),
               PeriodType.monthly),OperationType.Home);

            Account.NewOperation(Operation);
            Account.NewOperation(Operation2);


            var result = Account.GetBalanceAtDate(new DateOnly(2024, 1, 1));


        }
    }
}
