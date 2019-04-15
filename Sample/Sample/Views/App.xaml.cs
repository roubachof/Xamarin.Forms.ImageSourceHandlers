using SDWebImage.Forms.Sample.Views;

using Xamarin.Forms;

namespace SDWebImageForms.Sample.Views
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage (new MainPage ());
		}
	}
}
