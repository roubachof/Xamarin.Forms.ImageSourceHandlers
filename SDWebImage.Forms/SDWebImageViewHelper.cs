using System;
using System.Threading;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using Xamarin.Forms;

namespace SDWebImage.Forms
{
    [Preserve]
    internal static class SDWebImageViewHelper
    {
        private static Task<UIImage> LoadImageAsync(string urlString)
        {
            var tcs = new TaskCompletionSource<UIImage>();

            SDWebImageManager.SharedManager.LoadImage(
                new NSUrl(urlString),
                SDWebImageOptions.ScaleDownLargeImages,
                null,
                (image, data, error, cacheType, finished, url) =>
                    {
                        if (image == null)
                        {
                            Forms.Debug("Fail to load image: {0}", url.AbsoluteUrl);
                        }

                        tcs.SetResult(image);
                    });

            return tcs.Task;
        }


        public static async Task<UIImage> LoadViaSDWebImage(
            ImageSource source,
            CancellationToken token)
        {
            UIImage result = null;

            try
            {
                switch (source)
                {
                    case UriImageSource uriSource:
                        var urlString = uriSource.Uri.OriginalString;
                        Forms.Debug("Loading `{0}` as a web URL", urlString);
                        result = await LoadImageAsync(urlString);
                        break;
                }
            }
            catch (Exception exception)
            {
                // Since developers can't catch this themselves, I think we should log it and silently fail
                Forms.Warn("Unexpected exception in SDWebImage: {0}", exception);
            }

            return result;
        }
    }
}