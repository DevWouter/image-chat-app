using FinalDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Services
{
    public class ChatService
    {
        public IEnumerable<Chat> GetForImageId(int imageId)
        {
            return Store.ReadJsonFromFile<IEnumerable<Chat>>(StorePaths.Messages)
                .Where(x=> x.ImageId == imageId);
        }

        public Chat Create(int imageId, Account account, string message)
        {
            var chats = Store.ReadJsonFromFile<List<Chat>>(StorePaths.Messages);

            var nextId = chats
                .Select(x => x.Id)
                .OrderByDescending(x => x)
                .FirstOrDefault() + 1;

            var newChat = new Chat
            {
                Id = nextId,
                ImageId = imageId,
                UserId = account.Id,
                Content = message,
            };

            chats.Add(newChat);

            Store.WriteJsonToFile(StorePaths.Messages, chats);

            return newChat;
        }
    }
}
