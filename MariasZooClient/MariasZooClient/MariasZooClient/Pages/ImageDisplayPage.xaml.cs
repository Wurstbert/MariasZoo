using MariasZooClient.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MariasZooClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDisplayPage : ContentPage
    {
        ObservableCollection<ImageContainer> imageContainerList = new ObservableCollection<ImageContainer>()
        {
            new ImageContainer() { Title = "Katze 1", Date = DateTime.Now, SourceUrl = "http://r.ddmcdn.com/s_f/o_1/cx_462/cy_245/cw_1349/ch_1349/w_720/APL/uploads/2015/06/caturday-shutterstock_149320799.jpg" },
            new ImageContainer() { Title = "Katze 2", Date = DateTime.Now, SourceUrl = "http://www.readersdigest.ca/wp-content/uploads/2011/01/4-ways-cheer-up-depressed-cat.jpg" },
            new ImageContainer() { Title = "Katze 3", Date = DateTime.Now, SourceUrl = "http://www.petmd.com/sites/default/files/what-does-it-mean-when-cat-wags-tail.jpg" },
            new ImageContainer() { Title = "Katze 3", Date = DateTime.Now, SourceUrl = "http://www.catgifpage.com/gifs/318.gif" },
            new ImageContainer() { Title = "Katze 3", Date = DateTime.Now, SourceUrl = "https://media.giphy.com/media/6GpiRjfW6j2Ss/giphy.gif" }
        };

        public ImageDisplayPage()
        {
            InitializeComponent();

            this.ImageListView.ItemsSource = imageContainerList;
        }
    }
}