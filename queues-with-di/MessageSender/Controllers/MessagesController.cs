using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MessageSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly QueueClient _queueClient;

        public MessagesController(QueueClient queueClient)
        {
            _queueClient = queueClient ?? throw new ArgumentNullException(nameof(queueClient));
        }

        [HttpPost]
        public IActionResult Send([FromBody] QueueMessage queueMessage)
        {
            _queueClient.SendMessage(queueMessage.Message);
            return Ok();
        }
    }
}
