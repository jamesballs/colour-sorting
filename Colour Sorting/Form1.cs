using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colour_Sorting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int width = 1024;
            int height = 128;

            Bitmap img = new Bitmap(width, height);

            pictureBox1.Width = width;
            pictureBox1.Height = height;

            Random rnd = new Random();

            int[] rgb;

            for (int row = 0; row < img.Width; row++)
            {
                rgb = new int[3];

                int[] zeroonetwo = { 0, 1, 2 };

                int onetosix = rnd.Next(1, 7);

                switch (onetosix)
                {
                    case 1:
                        zeroonetwo = new int[] { 0, 1, 2 };
                        break;
                    case 2:
                        zeroonetwo = new int[] { 1, 0, 2 };
                        break;
                    case 3:
                        zeroonetwo = new int[] { 2, 0, 1 };
                        break;
                    case 4:
                        zeroonetwo = new int[] { 2, 1, 0 };
                        break;
                    case 5:
                        zeroonetwo = new int[] { 0, 2, 1 };
                        break;
                    case 6:
                        zeroonetwo = new int[] { 1, 2, 0 };
                        break;
                }

                rgb[zeroonetwo[0]] = rnd.Next(0, 256);
                rgb[zeroonetwo[1]] = 0;
                rgb[zeroonetwo[2]] = 255;

                img.SetPixel(row, 1, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
            }

            using (Graphics grD = Graphics.FromImage(img))
            {
                Image copy = img.Clone(new Rectangle(0, 1, img.Width, 1), System.Drawing.Imaging.PixelFormat.DontCare);

                for (int col = 2; col < img.Height - 1; col++)
                {
                    grD.DrawImage(copy, new Point(0, col));
                }
            }

            pictureBox1.Image = img;
            pictureBox1.Refresh();

                bool finished = false;

                while (!finished)
                {
                    Stopwatch stopWatchSub = new Stopwatch();
                    stopWatchSub.Start();

                    finished = true;

                    for (int row = 0; row < img.Width - 1; row++)
                    {
                        if (img.GetPixel(row, 1).GetHue() < img.GetPixel(row + 1, 1).GetHue())
                        {
                            finished = false;
                            break;
                        }
                    }

                    for (int row = 0; row < img.Width; row++)
                    {
                        if (row + 1 != img.Width)
                        {
                            if (img.GetPixel(row, 1).GetHue() < img.GetPixel(row + 1, 1).GetHue())
                            {
                                Color second = img.GetPixel(row + 1, 1);

                                img.SetPixel(row + 1, 1, img.GetPixel(row, 1));
                                img.SetPixel(row, 1, second);
                            }
                        }
                }

                using (Graphics grD = Graphics.FromImage(img))
                {
                    Image copy = img.Clone(new Rectangle(0, 1, img.Width, 1), System.Drawing.Imaging.PixelFormat.DontCare);

                    for (int col = 2; col < img.Height - 1; col++)
                    {
                        grD.DrawImage(copy, new Point(0, col));
                    }
                }

                pictureBox1.Image = img;
                pictureBox1.Refresh();

                stopWatchSub.Stop();

                string perSec = (0.001 / ((double)stopWatchSub.ElapsedMilliseconds / (double)1000)).ToString();

                label2.Text = perSec;
                this.label2.Refresh();
                }
            
            
            
            pictureBox1.Image = img;
            pictureBox1.Refresh();

            stopwatch.Stop();

            label4.Text = (stopwatch.ElapsedMilliseconds / 1000).ToString() + " seconds";
            this.label4.Refresh();
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int width = 1024;
            int height = 128;

            Bitmap img = new Bitmap(width, height);

            pictureBox2.Width = width;
            pictureBox2.Height = height;

            Random rnd = new Random();

            int[] rgb;

            for (int row = 0; row < img.Width; row++)
            {
                rgb = new int[3];

                int[] zeroonetwo = { 0, 1, 2 };

                int onetosix = rnd.Next(1, 7);

                switch (onetosix)
                {
                    case 1:
                        zeroonetwo = new int[] { 0, 1, 2 };
                        break;
                    case 2:
                        zeroonetwo = new int[] { 1, 0, 2 };
                        break;
                    case 3:
                        zeroonetwo = new int[] { 2, 0, 1 };
                        break;
                    case 4:
                        zeroonetwo = new int[] { 2, 1, 0 };
                        break;
                    case 5:
                        zeroonetwo = new int[] { 0, 2, 1 };
                        break;
                    case 6:
                        zeroonetwo = new int[] { 1, 2, 0 };
                        break;
                }

                rgb[zeroonetwo[0]] = rnd.Next(0, 256);
                rgb[zeroonetwo[1]] = 0;
                rgb[zeroonetwo[2]] = 255;

                img.SetPixel(row, 1, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
            }

            using (Graphics grD = Graphics.FromImage(img))
            {
                Image copy = img.Clone(new Rectangle(0, 1, img.Width, 1), System.Drawing.Imaging.PixelFormat.DontCare);

                for (int col = 2; col < img.Height - 1; col++)
                {
                    grD.DrawImage(copy, new Point(0, col));
                }
            }

            pictureBox2.Image = img;
            pictureBox2.Refresh();



            void Quicksort(IComparable[] elements, int left, int right)
            {
                int i = left, j = right;
                IComparable pivot = elements[(left + right) / 2];

                while (i <= j)
                {
                    while (elements[i].CompareTo(pivot) < 0)
                    {
                        i++;
                    }

                    while (elements[j].CompareTo(pivot) > 0)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        // Swap
                        IComparable tmp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = tmp;

                        i++;
                        j--;
                    }
                }

                // Recursive calls
                if (left < j)
                {
                    Quicksort(elements, left, j);
                }

                if (i < right)
                {
                    Quicksort(elements, i, right);
                }
            }

            //bool finished = false;

            //List<Color> pivot = new List<Color>();

            //List<int> currentRow = new List<int>();

            //pivot.Add(img.GetPixel((img.Width + 1) / 2, 1));

            //int i = 0;

            //while (!finished)
            //{
            //    Stopwatch stopWatchSub = new Stopwatch();
            //    stopWatchSub.Start();

            //    List<List<Color>> colorListGreater = new List<List<Color>>();
            //    List<List<Color>> colorListSmaller = new List<List<Color>>();

            //    int currentp = 0;

            //    for (int test = 0; test < pivot.Count; test++)
            //    {
            //        colorListGreater.Add(new List<Color>());
            //        colorListSmaller.Add(new List<Color>());

            //        for (int row = 0; row < (((img.Width + 1) / 2) - 1); row++)
            //        {
            //            Color current = img.GetPixel(row, 1);

            //            if (current.GetHue() < pivot[test].GetHue())
            //            {
            //                colorListSmaller[currentp].Add(current);
            //            }

            //            if (current.GetHue() > pivot[test].GetHue())
            //            {
            //                colorListGreater[currentp].Add(current);
            //            }
            //        }

            //        for (int row = (((img.Width + 1) / 2) + 1); row < img.Width; row++)
            //        {
            //            Color current = img.GetPixel(row, 1);

            //            if (current.GetHue() < pivot[test].GetHue())
            //            {
            //                colorListSmaller[currentp].Add(current);
            //            }

            //            if (current.GetHue() > pivot[test].GetHue())
            //            {
            //                colorListGreater[currentp].Add(current);
            //            }
            //        }


            //        foreach (Color c in colorListSmaller[currentp])
            //        {
            //            currentRow.Add(0);

            //            img.SetPixel(currentRow[currentp], 1, c);

            //            currentRow[currentp]++;

            //            using (Graphics grD = Graphics.FromImage(img))
            //            {
            //                Image copy = img.Clone(new Rectangle(0, 1, img.Width, 1), System.Drawing.Imaging.PixelFormat.DontCare);

            //                for (int col = 2; col < img.Height - 1; col++)
            //                {
            //                    grD.DrawImage(copy, new Point(0, col));
            //                }
            //            }

            //            pivot.Add(img.GetPixel(currentRow[currentp], 1));

            //            pictureBox2.Image = img;
            //            pictureBox2.Refresh();
            //        }

            //        img.SetPixel(currentRow[currentp], 1, pivot[test]);

            //        foreach (Color c in colorListGreater[currentp])
            //        {
            //            currentRow[currentp] = 0;

            //            img.SetPixel(currentRow[currentp], 1, c);

            //            currentRow[currentp]++;

            //            using (Graphics grD = Graphics.FromImage(img))
            //            {
            //                Image copy = img.Clone(new Rectangle(0, 1, img.Width, 1), System.Drawing.Imaging.PixelFormat.DontCare);

            //                for (int col = 2; col < img.Height - 1; col++)
            //                {
            //                    grD.DrawImage(copy, new Point(0, col));
            //                }
            //            }

            //            pivot.Add(img.GetPixel(currentRow[currentp], 1));

            //            pictureBox2.Image = img;
            //            pictureBox2.Refresh();
            //        }

            //        currentp++;
            //    }

            //    foreach (Color p in pivot)
            //    {

            //    }



            //    pictureBox2.Image = img;
            //    pictureBox2.Refresh();

            //    stopWatchSub.Stop();

            //    string perSec = (0.001 / ((double)stopWatchSub.ElapsedMilliseconds / (double)1000)).ToString();

            //    label2.Text = perSec;
            //    this.label2.Refresh();

            //    i++;
            //}


            //for (int row = 0; row < img.Width - 1; row++)
            //{
            //    if (img.GetPixel(row, 1).GetHue() < img.GetPixel(row + 1, 1).GetHue())
            //    {
            //        finished = false;
            //        break;
            //    }
            //}

            //for (int row = 0; row < img.Width; row++)
            //{
            //    if (row + 1 != img.Width)
            //    {
            //        if (img.GetPixel(row, 1).GetHue() < img.GetPixel(row + 1, 1).GetHue())
            //        {
            //            Color second = img.GetPixel(row + 1, 1);

            //            img.SetPixel(row + 1, 1, img.GetPixel(row, 1));
            //            img.SetPixel(row, 1, second);
            //        }
            //    }
            //}


            pictureBox2.Image = img;
            pictureBox2.Refresh();

            stopwatch.Stop();

            label4.Text = (stopwatch.ElapsedMilliseconds / 1000).ToString() + " seconds";
            this.label4.Refresh();
        }

        public static int[] GenerateRGB()
        {
            Random rnd = new Random();

            int[] rgb = new int[3];

            int[] zeroonetwo = { 0, 1, 2 };

            int onetosix = rnd.Next(1, 7);

            switch (onetosix)
            {
                case 1:
                    zeroonetwo = new int[] { 0, 1, 2 };
                    break;
                case 2:
                    zeroonetwo = new int[] { 1, 0, 2 };
                    break;
                case 3:
                    zeroonetwo = new int[] { 2, 0, 1 };
                    break;
                case 4:
                    zeroonetwo = new int[] { 2, 1, 0 };
                    break;
                case 5:
                    zeroonetwo = new int[] { 0, 2, 1 };
                    break;
                case 6:
                    zeroonetwo = new int[] { 1, 2, 0 };
                    break;
            }

            rgb[zeroonetwo[0]] = rnd.Next(0, 256);
            rgb[zeroonetwo[1]] = 0;
            rgb[zeroonetwo[2]] = 255;

            return rgb;
        }
    }
}
