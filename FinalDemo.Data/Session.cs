using System;
using System.Collections.Generic;
using System.Text;

namespace FinalDemo.Data
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid SessionKey { get; set; }
    }
}
