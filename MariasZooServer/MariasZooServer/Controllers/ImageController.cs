using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MariasZooServer.BusinessObjects;
using MariasZooServer.Models;
using System.Globalization;

namespace MariasZooServer.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        // GET api/image/2016-09-06-14-00
        [HttpGet("{dateString}")]
        public IEnumerable<ImageContainer> GetNewerImagesThan(string dateString)
        {
            try
            {
                DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture);

                return AnimalModel.Instance.GetNewerImagesThan(date);
            }
            catch
            {
                return null;
            }
        }
    }
}
