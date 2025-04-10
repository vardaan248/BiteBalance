using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SubscriptionService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly Application.Services.SubscriptionService _subscriptionService;

        public SubscriptionController(Application.Services.SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("available-plans")]
        [AllowAnonymous]
        public IActionResult GetAvailablePlans()
        {
            var plans = new[] { "Weekly", "Monthly", "SixMonth", "Yearly" };
            return Ok(plans);
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscriptionRequestDto request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _subscriptionService.SubscribeAsync(userId, request.PlanType);
            return Ok("Subscribed successfully!");
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMySubscriptions()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var subs = await _subscriptionService.GetUserSubscriptionsAsync(userId);
            return Ok(subs);
        }

        [HttpDelete("cancel/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _subscriptionService.CancelAsync(id);
            return Ok("Subscription cancelled");
        }
    }
}
