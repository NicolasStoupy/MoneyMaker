using System;
using System.Collections.Generic;

namespace Infrastructure.EntityModels;

public partial class ApplicationUser
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Forname { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
}
