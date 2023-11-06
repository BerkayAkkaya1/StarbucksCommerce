using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressName { get; set; } = null!;

    public byte[] AddressDescription { get; set; } = null!;

    public int MemberId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Member Member { get; set; } = null!;
}
