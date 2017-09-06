using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MariasZooServer.BusinessObjects;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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

        private string connectionString;

        private AnimalModel()
        {

            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
            connectionStringBuilder.Server = "127.0.0.1";
            connectionStringBuilder.UserID = "root";
            connectionStringBuilder.Password = "123";
            connectionStringBuilder.Database = "mariaszoo";
            connectionStringBuilder.SslMode = MySqlSslMode.None;

            this.connectionString = connectionStringBuilder.ToString();
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
            List<ImageContainer> imageContainerList = new List<ImageContainer>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select * from imagecontainers", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        imageContainerList.Add(new ImageContainer
                        {
                            Date = DateTime.Parse(reader["date"].ToString())
                        });
                    }
                }
            }

            return imageContainerList;
        }

        public bool IsNewerImageAvailable(DateTime date)
        {
            bool isNewerImageAvailable = false;

            /*using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select * from imagecontainers", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        imageContainerList.Add(new ImageContainer
                        {
                            Date = DateTime.Parse(reader["date"].ToString())
                        });
                    }
                }
            }*/

            return isNewerImageAvailable;
        }
    }
}
