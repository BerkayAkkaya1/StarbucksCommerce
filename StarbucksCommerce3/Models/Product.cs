using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductCategory { get; set; }

    public decimal? ProductPrice { get; set; }

    public int? ProductStock { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
