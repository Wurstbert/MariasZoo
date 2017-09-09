using MariasZooClient.BusinessObjects;
using MariasZooClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MariasZooClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDisplayPage : ContentPage
    {
        public ImageDisplayPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            try
            {
                var result = await ServerModel.Instance.GetNewerImagesThan(new DateTime(2016, 11, 6));
                Stream receiveStream = await result.Content.ReadAsStreamAsync();
                StreamReader readStream = new StreamReader(receiveStream);
                var resultString = readStream.ReadToEnd();
                this.ImageListView.ItemsSource = JsonConvert.DeserializeObject<ObservableCollection<ImageContainer>>(resultString);
            }
            catch (Exception e)
            {
                // TODO: Show error message in GUI
            }
        }
    }
}