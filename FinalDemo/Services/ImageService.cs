using FinalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Services
{
    public class ImageService
    {
        public IEnumerable<ImageDto> GetAll()
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
