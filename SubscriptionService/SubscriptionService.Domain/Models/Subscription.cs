public class Subscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } // link to User
    public string PlanType { get; set; } = string.Empty; // Weekly, Monthly, etc.
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public decimal Price { get; set; }
}

public enum SubscriptionPlan
{
    Weekly,
    Monthly,
    SixMonth,
    Yearly
}
