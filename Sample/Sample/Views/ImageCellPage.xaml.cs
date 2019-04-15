using System.Linq;

namespace SDWebImage.Forms.Sample.Views
{
	public partial class ImageCellPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

			BindingContext = Images.Sources(1000).ToArray ();
		}
	}
}