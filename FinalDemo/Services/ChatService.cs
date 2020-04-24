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
    }
}
