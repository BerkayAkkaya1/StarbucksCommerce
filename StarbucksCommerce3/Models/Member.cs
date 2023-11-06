using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string? MemberName { get; set; }

    public string? MemberSurname { get; set; }

    public string? MemberMail { get; set; }

    public string? MemberPassword { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsBlocked { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Point> Points { get; set; } = new List<Point>();

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
