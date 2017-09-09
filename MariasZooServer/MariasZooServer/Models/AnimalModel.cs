using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariasZooServer.BusinessObjects;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;

namespace MariasZooServer.Models
{
    public sealed class AnimalModel
    {
        private static volatile AnimalModel instance;

        /*private List<ImageContainer> testImageList = new List<ImageContainer>()
        {
            new ImageContainer() {Date = DateTime.Now, Image = new ImageSharp.Image(@"C:\Zufaelliges\AverageDayProgrammer.png")},
            new ImageContainer() {Date = new DateTime(1066, 5, 5), Image = new ImageSharp.Image(@"C:\Zufaelliges\hosen.jpg")}
        };*/

        private static object instanceLock = new object();

        private string connectionString;

        private string baseImagesUrl;

        private AnimalModel()
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
            connectionStringBuilder.Server = "127.0.0.1";
            connectionStringBuilder.UserID = "root";
            connectionStringBuilder.Password = "123";
            connectionStringBuilder.Database = "mariaszoo";
            connectionStringBuilder.SslMode = MySqlSslMode.None;

            this.connectionString = connectionStringBuilder.ToString();

            this.baseImagesUrl = "http://" + GetPublicIPAddress() + ":25184/images/";
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

        static string GetPublicIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;
        }

        public IEnumerable<ImageContainer> GetNewerImagesThan(DateTime date)
        {
            List<ImageContainer> imageContainerList = new List<ImageContainer>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select * from imagecontainers where date > @compareDate", connection);
                command.Parameters.AddWithValue("@compareDate", date);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        imageContainerList.Add(new ImageContainer
                        {
                            Date = DateTime.Parse(reader["date"].ToString()),
                            SourceUrl = this.baseImagesUrl + reader["filename"].ToString(),
                            Title = reader["title"].ToString()
                        });
                    }
                }
            }

            return imageContainerList;
        }

        public bool IsNewerImageAvailable(DateTime date)
        {
            bool isNewerImageAvailable = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select count(*) from imagecontainers where date > @compareDate", connection);
                command.Parameters.AddWithValue("@compareDate", date);

                // This counts the number of returned rows of the command
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                {
                    isNewerImageAvailable = true;

                }
            }

            return isNewerImageAvailable;
        }
    }
}
