using System.Collections.Generic;
using Xamarin.Forms;
using ZXing;

namespace readBarcode
{
	public partial class readBarcodePage : ContentPage
	{
		BarcodeDecoding barcode;

		public readBarcodePage()
		{
			barcode = new BarcodeDecoding();

			InitializeComponent();

			BindingContext = this;
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var aditionalHints = new KeyValuePair<DecodeHintType, object>(key: DecodeHintType.PURE_BARCODE, value: "TRUE");

			var result = barcode.Decode(file: "", format: BarcodeFormat.QR_CODE, aditionalHints: new [] {aditionalHints } );

			QrResult.Text = result.Text;
		}
	}
}
