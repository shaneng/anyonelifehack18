using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AiFamily
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_AcceptChallenge : ContentPage
	{
		public Page_AcceptChallenge ()
		{
			InitializeComponent ();
		}

        async void ChallengeAcceptedButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_ChallengeDetail());
        }

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}