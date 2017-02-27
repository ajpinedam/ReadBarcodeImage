using System;
using ZXing;

namespace readBarcode
{
	public interface IImageHelper
	{
		BinaryBitmap GetBinaryBitmap(byte[] image);
	}
}
