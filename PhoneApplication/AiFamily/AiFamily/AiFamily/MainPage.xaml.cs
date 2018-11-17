using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AiFamily
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void YesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_AcceptChallenge());
        }
    }
}
