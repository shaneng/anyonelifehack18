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
	public partial class Page_StartChallenge : ContentPage
	{
      
        public Page_StartChallenge ()
		{
            InitializeComponent();
            DelayTask();

            var i = 3;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Label.FontSize = 100;
                Label.TextColor = Color.Black;
                Label.Text = i.ToString();
                i--;

                if (i >= 0)
                    return true;
                else
                {
                    StartWorkOut();
                    return false;
                }
            });
           
        }

        private async void DelayTask()
        {
            await Task.Delay(1000);
        }

        async void StartWorkOut()
        {
            DelayTask();
            await Navigation.PushAsync(new Page_ChallengeProgress());
        }
    }
}