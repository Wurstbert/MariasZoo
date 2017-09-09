using MariasZooClient.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MariasZooClient.Models
{
    public class ServerModel
    {
        private static volatile ServerModel instance;

        private static object instanceLock = new object();

        private string baseImageUrl;

        private string baseImageControllerUrl;

        private ServerModel()
        {
            this.baseImageUrl = "http://31.16.100.81:25184/images/";
            this.baseImageControllerUrl = "http://31.16.100.81:25184/api/image/";
        }

        public static ServerModel Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ServerModel();
                    }
                }
                return instance;
            }
        }

        public async Task<HttpResponseMessage> GetNewerImagesThan(DateTime date)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(this.baseImageControllerUrl + "2016-11-06-12-45");

            return response;
        }
    }
}
