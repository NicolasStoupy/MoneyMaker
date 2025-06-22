using System;
using System.Collections.Generic;

namespace Infrastructure.EntityModels;

public partial class Operation
{
    public int OperationId { get; set; }

    public string? Name { get; set; }

    public decimal? Amount { get; set; }

    public string? BankAccountId { get; set; }

    public int ProviderId { get; set; }

    public int PeriodId { get; set; }

    public virtual BankAccount? BankAccount { get; set; }

    public virtual Period Period { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;
}
