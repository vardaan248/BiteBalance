public interface ISubscriptionRepository
{
    Task<List<Subscription>> GetAllByUserAsync(Guid userId);
    Task<Subscription?> GetActiveSubscriptionAsync(Guid userId);
    Task AddAsync(Subscription subscription);
    Task CancelAsync(Guid subscriptionId);
}
