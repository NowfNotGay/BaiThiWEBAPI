using System;
using System.Collections.Generic;

namespace BaiThiWEBAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Datecreation { get; set; } = null!;

    public bool Status { get; set; }

    public string Payments { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
