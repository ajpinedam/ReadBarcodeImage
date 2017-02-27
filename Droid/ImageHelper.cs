using System;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Graphics;
using Android.App;
using Android.Content;
using ZXing;
using ZXing.Common;
using readBarcode.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ImageHelper))]
namespace readBarcode.Droid
{
	public class ImageHelper : IImageHelper
	{
		Context context;

		public ImageHelper()
		{
			context = Xamarin.Forms.Forms.Context;
		}

		public BinaryBitmap GetBinaryBitmap(byte[] image)
		{
			//Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);

			Bitmap bitmap = BitmapFactory.DecodeStream(context.Resources.OpenRawResource(Resource.Raw.static_qr_code_without_logo));
			byte[] rgbBytes = GetRgbBytes(bitmap);
			var bin = new HybridBinarizer(new RGBLuminanceSource(rgbBytes, bitmap.Width, bitmap.Height));
			var i = new BinaryBitmap(bin);

			return i;
		}

		private byte[] GetRgbBytes(Bitmap image)
		{
			var rgbBytes = new List<byte>();
			for (int y = 0; y < image.Height; y++)
			{
				for (int x = 0; x < image.Width; x++)
				{
					var c = new Color(image.GetPixel(x, y));

					rgbBytes.AddRange(new[] { c.R, c.G, c.B });
				}
			}
			return rgbBytes.ToArray();
		}

	}
}
