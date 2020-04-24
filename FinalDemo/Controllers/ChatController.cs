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
        private readonly AccountService _accountService;

        public ChatController(ChatService chatService, AccountService accountService)
        {
            _chatService = chatService;
            _accountService = accountService;
        }

        [HttpGet]
        [Route("{imageId}")]
        public IEnumerable<ChatDto> GetMessageForImage(int imageId)
        {
            var allMessages = _chatService.GetForImageId(imageId);
            return allMessages.AsParallel().AsOrdered().WithDegreeOfParallelism(20)
                .Select(x => new ChatDto()
            {
                Message = x.Content,
                Username = _accountService.FindById(x.UserId).Name
            });
        }

        [HttpPost]
        [Route("{imageId}")]
        public IActionResult PostMessageForImage(int imageId, ChatRequest body)
        {
            try
            {
                var user = _accountService.FindBySessionKey(body.SessionKey);
                var chat = _chatService.Create(imageId, user, body.Message);
                return Ok(chat);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
