using System;
using System.Collections.Generic;

namespace Infrastructure.EntityModels;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string? ProviderName { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
