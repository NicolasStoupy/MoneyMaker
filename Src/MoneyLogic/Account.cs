namespace MoneyLogic
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public string Name { get;private set; }
        private decimal _amount { get; set; }

        private List<Operation> _operations = new List<Operation>();

        public Account (string accountNumber, string name)
        {
            AccountNumber = accountNumber;
            Name = name;
        }

        public void SetBalance(decimal balance)
        {
            _amount = balance;
        }
        public void NewOperation(Operation operation)
        {
            _operations.Add(operation);
        }
        public decimal GetBalanceAtDate(DateOnly targetDate)
        {
            var balance = _amount;

            foreach (var operation in _operations)
            {
                if (operation.Periods == null)
                    continue;
                if (operation.Periods.StartDate > targetDate)
                    continue;
                var count = operation.Periods.CountExecutionsUntil(targetDate);

                balance += count * operation.Amount;
            }

            return balance;
        }
    }
}