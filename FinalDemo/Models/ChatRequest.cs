using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Models
{
    public class ChatRequest
    {
        public Guid SessionKey { get; set; }
        public string Message { get; set; }
    }
}
