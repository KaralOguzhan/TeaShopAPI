using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinesLayer.Abstract;
using TeaShopApi.DtoLayer.MessageDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                MessageDetail = createMessageDto.MessageDetail,
                MessageEmail = createMessageDto.MessageEmail,
                MessageSenderName = createMessageDto.MessageSenderName,
                MessageSubject = createMessageDto.MessageSubject,
                MessageSendDate = DateTime.Now
            };
            _messageService.TInsert(message);
            return Ok("Mesaj başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetById(id);
            _messageService.TDelete(values);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi");

        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                MessageDetail = updateMessageDto.MessageDetail,
                MessageEmail = updateMessageDto.MessageEmail,
                MessageSenderName = updateMessageDto.MessageSenderName,
                MessageSubject = updateMessageDto.MessageSubject,
                MessageSendDate = DateTime.Now
            };
            _messageService.TInsert(message);
            return Ok("Mesaj başarılı bir şekilde Güncellendi");
        }

    }
}
