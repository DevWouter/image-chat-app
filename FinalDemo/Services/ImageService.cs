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
            return Store.ReadJsonFromFile<IEnumerable<ImageDto>>(StorePaths.Images);
        }
    }
}
