using StepsCounterApp;
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
	public partial class Page_ChallengeProgress : ContentPage
	{
		public Page_ChallengeProgress ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FetchHealthData();
        }

        void FetchHealthData()
        {
            //List<Task> tasks = new List<Task>();
            //DependencyService.Get<IHealthData>().GetHealthPermissionAsync((result) =>

        }
    }
}