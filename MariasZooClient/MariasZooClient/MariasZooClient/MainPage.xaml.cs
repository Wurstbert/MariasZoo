using MariasZooClient.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MariasZooClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoButtonClicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new ImageDisplayPage());
        }
    }
}
