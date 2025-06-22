using System;
using System.Collections.Generic;

namespace Infrastructure.EntityModels;

public partial class BankAccount
{
    public string BankAccountId { get; set; } = null!;

    public decimal Amount { get; set; }

    public int OwnerId { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual ApplicationUser Owner { get; set; } = null!;
}
