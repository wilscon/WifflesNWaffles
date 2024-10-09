using System.Drawing.Imaging;
using System.Drawing;

namespace WifflesNWaffles.Utilities
{
    public static class ProfileImageGenerator
    {
        public static string GenerateProfileImageBase64(string initials, int width, int height)
        {
            using (Bitmap bitmap = GenerateProfileImage(initials, width, height))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the image to the memory stream as PNG
                    bitmap.Save(ms, ImageFormat.Png);

                    // Convert the byte array to Base64 string
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    return "data:image/png;base64," + base64String;
                }
            }
        }

        public static Bitmap GenerateProfileImage(string initials, int width, int height)
        {
            Random random = new Random();

            // Create a blank canvas
            Bitmap bitmap = new Bitmap(width, height);

            // Create random background color
            Color backgroundColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            // Fill the canvas with the background color
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(backgroundColor);

                // Create font for initials
                System.Drawing.Font font = new System.Drawing.Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                // Set text color (contrast to background)
                Brush textBrush = new SolidBrush(Color.White);

                // Measure the size of the initials text
                SizeF textSize = g.MeasureString(initials, font);

                // Draw the initials in the center of the image
                g.DrawString(initials, font, textBrush,
                             (width - textSize.Width) / 2,
                             (height - textSize.Height) / 2);
            }

            return bitmap;
        }

    }
}
