using System.Linq;

namespace SDWebImage.Forms.Sample.Views
{
	public partial class ViewCellPage
	{
		public ViewCellPage ()
		{
			InitializeComponent ();

			BindingContext = Images.Sources().ToArray ();
		}
	}
}