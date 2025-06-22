namespace MoneyLogic
{
    public class Operation
    {
        public Operation(string name, decimal amount, Periods periods, OperationType operationType =OperationType.Fix)
        {
            Name = name;
            Amount = amount;
            Periods = periods;
            OperationType = operationType;
        }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public Periods Periods { get; private set; }

        public OperationType OperationType { get; private set; }


    }
    public enum OperationType
    {
        Fix, Extra,
        Home
    }
}