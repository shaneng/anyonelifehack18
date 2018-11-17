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
	public partial class Page_ChallengeDetail : ContentPage
	{
		public Page_ChallengeDetail ()
		{
			InitializeComponent ();
		}

        async void YesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_StartChallenge());
        }

        async void NoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_AcceptChallenge());
        }

        async  void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_AcceptChallenge());
        }
    }
}