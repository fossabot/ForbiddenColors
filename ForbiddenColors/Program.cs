using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ForbiddenColors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the width of the bitmap :");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the height of the bitmap :");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the first color :");
            string firstColor = Console.ReadLine();
            Console.WriteLine("Enter the second color :");
            string secondColor = Console.ReadLine();
            Bitmap b = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x % 2 == 0)
                    {
                        Color c = b.GetPixel(x, y);
                        b.SetPixel(x, y, Color.FromName(firstColor));
                        y++;
                        Color d = b.GetPixel(x, y);
                        b.SetPixel(x, y, Color.FromName(secondColor));
                    }
                    else
                    {
                        Color d = b.GetPixel(x, y);
                        b.SetPixel(x, y, Color.FromName(secondColor));
                        y++;
                        Color c = b.GetPixel(x, y);
                        b.SetPixel(x, y, Color.FromName(firstColor));
                    }
                }
                Console.WriteLine(x);
            }
            Console.Clear();
            string imageName = ".\\" + firstColor + secondColor + width.ToString() + height.ToString() + ".png";
            b.Save(imageName, ImageFormat.Png);
            Console.WriteLine("File saved as : " + imageName);
            Console.ReadKey();
        }
    }
}
