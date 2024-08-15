using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Notification_backend.Controllers
{

    public class Notification
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationsController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Notification notification)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
            return Ok();
        }
    }
}
