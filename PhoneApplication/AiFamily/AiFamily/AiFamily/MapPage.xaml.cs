using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AiFamily
{
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();

            //customMap.ShapeCoordinates.Add (new Position (37.797513, -122.402058));
            //customMap.ShapeCoordinates.Add (new Position (37.798433, -122.402256));
            //customMap.ShapeCoordinates.Add (new Position (37.798582, -122.401071));
            //customMap.ShapeCoordinates.Add (new Position (37.797658, -122.400888));

            customMap.ShapeCoordinates.Add(new Position(22.261740, 114.130485));
            customMap.ShapeCoordinates.Add(new Position( 22.261224, 114.130485));
            customMap.ShapeCoordinates.Add(new Position(22.261224, 114.130893));
            customMap.ShapeCoordinates.Add(new Position(22.261740, 114.130893));


            //customMap.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (37.79752, -122.40183), Distance.FromMiles (0.1)));
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(22.261740, 114.130485), Distance.FromMiles(0.1)));
            

            PhotoTakingBtn.Clicked += async (sender, args) =>
            {

                var options = new StoreCameraMediaOptions();


                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }
                try
                {
                    var file = await CrossMedia.Current.TakePhotoAsync(options);

                    if (file == null)
                        return;
                    else
                        try
                        {
                            // var result = await endPoint.PredictImageUrlWithHttpMessagesAsync(new Guid("e3196500-6df5-4639-98ac-627e204cc8b5"), file.GetStream());
                            await Navigation.PushAsync(new CompletedPage(file.GetStream()));
                        }
                        catch(Exception ex)
                        {

                        }

                    //var analysisResult = await AnalyzePictureAsync(file.GetStream());
                    //PhotoImage.Source = ImageSource.FromStream(() =>
                    //{
                    //    var stream = file.GetStream();
                    //    file.Dispose();
                    //    return stream;
                    //});
                    //var CompletedPage = new NavigationPage(new CompletedPage("/Sample/test.jpgs"));
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Xamarin.Insights.Report(ex);
                    await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
                }
            };


        }


        async  void BackButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Page_ChallengeDetail());
        }
    }
}
