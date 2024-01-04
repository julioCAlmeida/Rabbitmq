using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbitmq.Models;
using Rabbitmq.Services.Interfaces;

namespace Rabbitmq.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitmqMessageController : ControllerBase
    {
        private readonly IRabbitmqMessageService _service;

        public RabbitmqMessageController(IRabbitmqMessageService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddMessage(RabbitMessage message)
        {
            _service.SendMessage(message);
        }
    }
}
