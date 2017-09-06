using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariasZooServer.BusinessObjects;

namespace MariasZooServer.Models
{
    public sealed class AnimalModel
    {
        private static volatile AnimalModel instance;

        private List<ImageContainer> testImageList = new List<ImageContainer>()
        {
            new ImageContainer() {Date = DateTime.Now, Image = new ImageSharp.Image(@"C:\Zufaelliges\AverageDayProgrammer.png")},
            new ImageContainer() {Date = new DateTime(1066, 5, 5), Image = new ImageSharp.Image(@"C:\Zufaelliges\hosen.jpg")}
        };

        private static object instanceLock = new object();

        private AnimalModel()
        {
            ;
        }

        public static AnimalModel Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AnimalModel();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<ImageContainer> GetNewerImagesThan(DateTime date)
        {
            return this.testImageList;
        }

        public bool IsNewerImageAvailable(DateTime date)
        {
            return date < new DateTime(793, 6, 8);
        }
    }
}
