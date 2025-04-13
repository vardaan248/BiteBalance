using Common.Common.HttpClients.Sales;

namespace SubscriptionService.Application.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _repo;
        private SalesHttpClient _salesHttpClient;

        public SubscriptionService(ISubscriptionRepository repo, SalesHttpClient salesHttpClient)
        {
            _repo = repo;
            _salesHttpClient = salesHttpClient;
        }

        public async Task<List<SubscriptionDto>> GetUserSubscriptionsAsync(Guid userId)
        {
            var subs = await _repo.GetAllByUserAsync(userId);
            return subs.Select(s => new SubscriptionDto
            {
                Id = s.Id,
                PlanType = s.PlanType,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                IsActive = s.IsActive
            }).ToList();
        }

        public async Task SubscribeAsync(Guid userId, string planType)
        {
            var now = DateTime.UtcNow;
            var duration = planType.ToLower() switch
            {
                "weekly" => TimeSpan.FromDays(7),
                "monthly" => TimeSpan.FromDays(30),
                "sixmonth" => TimeSpan.FromDays(180),
                "yearly" => TimeSpan.FromDays(365),
                _ => throw new ArgumentException("Invalid plan type")
            };

            var sub = new Subscription
            {
                UserId = userId,
                PlanType = planType,
                StartDate = now,
                EndDate = now.Add(duration),
                IsActive = true
            };

            await _repo.AddAsync(sub);

            await _salesHttpClient.SendSaleAsync(new SaleRecordRequest
            {
                OrderId = sub.Id,
                Amount = sub.Price,
                Type = "Subscription"
            });
        }

        public Task CancelAsync(Guid subscriptionId)
        {
            return _repo.CancelAsync(subscriptionId);
        }
    }
}
