using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharp;

namespace MariasZooServer.BusinessObjects
{
    public class ImageContainer
    {
        public string SourceUrl { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}
