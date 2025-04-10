namespace SubscriptionService.Infrastructure.Repositories
{
    public class InMemorySubscriptionRepository : ISubscriptionRepository
    {
        private readonly List<Subscription> _subscriptions = new();

        public Task AddAsync(Subscription subscription)
        {
            _subscriptions.Add(subscription);
            return Task.CompletedTask;
        }

        public Task<List<Subscription>> GetAllByUserAsync(Guid userId)
        {
            var userSubscriptions = _subscriptions
                .Where(s => s.UserId == userId)
                .ToList();

            return Task.FromResult(userSubscriptions);
        }

        public Task<Subscription?> GetActiveSubscriptionAsync(Guid userId)
        {
            var active = _subscriptions.FirstOrDefault(s =>
                s.UserId == userId &&
                s.IsActive &&
                s.StartDate <= DateTime.UtcNow &&
                s.EndDate >= DateTime.UtcNow);

            return Task.FromResult(active);
        }

        public Task CancelAsync(Guid subscriptionId)
        {
            var subscription = _subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
            if (subscription != null)
            {
                subscription.IsActive = false;
                subscription.EndDate = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }
    }
}
