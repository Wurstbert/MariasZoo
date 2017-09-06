using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariasZooServer.BusinessObjects;
using MariasZooServer.Models;

namespace MariasZooServer.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        // GET api/image/2017-9-6
        [HttpGet("{dateString}")]
        public IEnumerable<ImageContainer> GetNewerImagesThan(string dateString)
        {
            DateTime date;
            if (DateTime.TryParse(dateString, out date))
            {
                return AnimalModel.Instance.GetNewerImagesThan(date);
            }

            return null;
        }
    }
}
