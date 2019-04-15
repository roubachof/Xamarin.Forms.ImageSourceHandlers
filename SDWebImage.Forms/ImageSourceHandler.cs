using System.Threading;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportImageSourceHandler(
    typeof(UriImageSource), typeof(SDWebImage.Forms.ImageSourceHandler))]

namespace SDWebImage.Forms
{
    [Preserve (AllMembers = true)]
    public class ImageSourceHandler : IImageSourceHandler
    {
        public Task<UIImage> LoadImageAsync(
            ImageSource imageSource,
            CancellationToken cancellationToken = new CancellationToken(),
            float scale = 1)
        {
            return SDWebImageViewHelper.LoadViaSDWebImage(
                imageSource, cancellationToken);
        }
    }
}