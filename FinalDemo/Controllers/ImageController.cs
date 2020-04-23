using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        public ImageController()
        {
        }

        [HttpGet]
        public IEnumerable<ImageDto> Get()
        {
            return new ImageDto[]
            {
                new ImageDto
                {
                    Id=1,
                    ImageUrl="my-first-image.png"
                },
                new ImageDto
                {
                    Id=2,
                    ImageUrl="my-second-image.png"
                },
            };
        }
    }
}
