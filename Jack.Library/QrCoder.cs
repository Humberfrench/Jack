using System.Drawing;
namespace Jack.Library
{
    public class QrCoder
    {
        public byte[] GerarQrCode(int width, int height, string texto)
        {
            var bw = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            var converter = new ImageConverter();
            var resultado = (byte[])converter.ConvertTo(bw.Write(texto), typeof(byte[]));
            return resultado;
        }
    }
}