using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AiFamily
{
	public partial class CompletedPage : ContentPage
	{
		public CompletedPage (Stream image_path)
		{
			InitializeComponent ();
            var endPoint = new WebClient();
            endPoint.Headers.Add("Prediction-Key", "0b8a75c791f74000afd451a5c1cc283a");
            endPoint.Headers.Add("Content-Type", "application/octet-stream");

            var output = new MemoryStream();
            image_path.CopyTo(output);
            // endPoint.UploadValuesCompleted += EndPoint_UploadValuesCompleted;
            var data = endPoint.UploadData(new Uri("https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/e3196500-6df5-4639-98ac-627e204cc8b5/image"), output.GetBuffer());
            StreamReader reader = new StreamReader(new MemoryStream(data));
            var result = reader.ReadToEnd();

            //ResultImage.Source = ImageSource.FromStream(() =>
            //{
            //    output.Seek(0, SeekOrigin.Begin);
            //    return output;
            //}
            //);

            
        }


        private void EndPoint_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            
        }
    }
}