using FinalDemo.Data;
using FinalDemo.Models;
using FinalDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        [Route("{imageId}")]
        public IEnumerable<ChatDto> GetMessageForImage(int imageId)
        {
            var allMessages = _chatService.GetForImageId(imageId);
            return allMessages.Select(x => new ChatDto()
            {
                Message = x.Content,
                Username = $"User {x.UserId}"
            });
        }
    }
}
