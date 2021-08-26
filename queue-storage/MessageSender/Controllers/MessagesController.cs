using MessageSender.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MessageSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private const string QUEUE_NAME = "message-queue";
        private readonly IQueueService _queueService;

        public MessagesController(IQueueService queueService)
        {
            _queueService = queueService ?? throw new ArgumentNullException(nameof(queueService));
        }

        [HttpPost]
        public IActionResult Send([FromBody] QueueMessage queueMessage)
        {
            _queueService.SendMessage(QUEUE_NAME, queueMessage.Message);
            return Ok();
        }
    }
}
