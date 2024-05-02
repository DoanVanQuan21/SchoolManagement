using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;

namespace SchoolManagement.Core.Helpers
{
    public class ImageHelper
    {
        public static FilePickerFileType ImageAll { get; } = new("All Images")
        {
            Patterns = new[] { "*.png", "*.jpg", "*.jpeg", "*.gif", "*.bmp", "*.webp" },
            AppleUniformTypeIdentifiers = new[] { "public.image" },
            MimeTypes = new[] { "image/*" }
        };
        public static Task<Bitmap?> LoadImageFromResourse(string resourse)
        {
            return Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(resourse))
                {
                    return null;
                }
                var uri = new Uri(resourse);
                return new Bitmap(AssetLoader.Open(uri));
            });
        }
    }
}