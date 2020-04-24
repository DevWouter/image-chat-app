using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalDemo.Models;
using FinalDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;

        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public IEnumerable<ImageDto> Get()
        {
            return _imageService.GetAll();
        }

        [HttpGet]
        [Route("{imageId}")]
        public ImageDto GetById(int imageId)
        {
            return _imageService.GetById(imageId);
        }
    }
}
