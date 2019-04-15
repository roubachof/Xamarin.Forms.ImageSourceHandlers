using System;

using SDWebImage.Forms.Sample.Profiler;

using Xamarin.Forms;

namespace SDWebImage.Forms.Sample.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (MemoryProfiler.Instance != null)
            {
                MemoryProfiler.Instance.Dispose();
                MemoryProfiler.Instance = null;
            }

            MemoryProfiler.Instance = new MemoryProfiler("Global");
        }

        async void GridOnlyRemote_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync (new GridOnlyRemotePage ());
        }
        async void Grid_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new GridPage ());
		}
		async void Edge_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new EdgeCasesPage ());
		}

		async void ViewCell_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ViewCellPage ());
		}

		async void ImageCell_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ImageCellPage ());
		}

		async void HugeImage_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new HugeImagePage ());
		}

		async void ToggleImages_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ToggleSourcePage ());
		}

		async void ToggleImagesMaterial_Clicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ToggleSourcePage());
		}
	}
}
