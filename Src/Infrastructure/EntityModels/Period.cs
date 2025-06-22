using System;
using System.Collections.Generic;

namespace Infrastructure.EntityModels;

public partial class Period
{
    public int PeriodId { get; set; }

    public string PeriodeType { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
