using MariasZooClient.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MariasZooClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDisplayPage : ContentPage
    {
        /*ObservableCollection<ImageContainer> imageContainerList = new ObservableCollection<ImageContainer>()
        {
            new ImageContainer() { Title = "Katze 1", Date = DateTime.Now, SourceUrl = "http://31.16.100.81:25184/images/cat1.jpg" },
            new ImageContainer() { Title = "Katze 2", Date = DateTime.Now, SourceUrl = "http://31.16.100.81:25184/images/cat2.jpg" },
            new ImageContainer() { Title = "Katze 3", Date = DateTime.Now, SourceUrl = "http://31.16.100.81:25184/images/cat3.jpg" },
            new ImageContainer() { Title = "Katze 4", Date = DateTime.Now, SourceUrl = "http://31.16.100.81:25184/images/cat4.gif" }
        };*/

        public ImageDisplayPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var result = await ServerModel.Instance.GetNewerImagesThan(new DateTime(2016, 11, 6));
            Stream receiveStream = await result.Content.ReadAsStreamAsync();
            StreamReader readStream = new StreamReader(receiveStream);
            var test = readStream.ReadToEnd();
            int a = 2;
            //this.ImageListView.ItemsSource =
        }
    }
}