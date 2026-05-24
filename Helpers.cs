using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace discos
{
    public static class Helpers
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null)
            {
                throw new ArgumentNullException(nameof(imageIn));
            }
            
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                throw new ArgumentException("Byte array is null or empty.", nameof(byteArrayIn));
            }

            MemoryStream ms = new MemoryStream(byteArrayIn);

            return Image.FromStream(ms);
        }
    }
}
