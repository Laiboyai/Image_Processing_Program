using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace image_process_assignmant_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = false; label2.Visible = false; label3.Visible = false;
            label4.Visible = false; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;
        }

        Bitmap openImg;
        //讀取圖片-Bitmap即為點陣圖
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = false; label2.Visible = false; label3.Visible = false;
            label4.Visible = false; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            //openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            // 選擇我們需要開檔的類型
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { // 如果成功開檔
                openImg = new Bitmap(openFileDialog1.FileName);
                // 宣告存取影像的 bitmap
                pictureBox1.Image = openImg;
                // 讀取的影像展示到 pictureBox
            }
        }

        //存取圖片
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openImg.Save(sfd.FileName);
                pictureBox1.Image.Save(sfd.FileName);
                pictureBox2.Image.Save(sfd.FileName);
                pictureBox3.Image.Save(sfd.FileName);
                pictureBox4.Image.Save(sfd.FileName);
            }
        }

        //(1-1)Color Extraction 
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "Sourse"; label2.Text = "R Channel";
            label3.Text = "G Channel"; label4.Text = "B Channel";

            int width = openImg.Width;
            int height = openImg.Height;

            Bitmap newImg1 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap newImg2 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap newImg3 = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    int invR = Convert.ToInt32(RGB.R);
                    int invG = Convert.ToInt32(RGB.G);
                    int invB = Convert.ToInt32(RGB.B);

                    Color newvalue1 = Color.FromArgb(invR, 0, 0);
                    Color newvalue2 = Color.FromArgb(0, invG, 0);
                    Color newvalue3 = Color.FromArgb(0, 0, invB);


                    newImg1.SetPixel(x, y, newvalue1);
                    newImg2.SetPixel(x, y, newvalue2);
                    newImg3.SetPixel(x, y, newvalue3);
                }
            }

            pictureBox1.Image = openImg;
            pictureBox2.Image = newImg1;
            pictureBox3.Image = newImg2;
            pictureBox4.Image = newImg3;

        }
        //(1-2)Color transformation 
        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "Grayscale"; label2.Text = "R channel";
            label3.Text = "G channel"; label4.Text = "B channel";

            int width = openImg.Width;
            int height = openImg.Height;

            Bitmap newImg1 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap newImg2 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap newImg3 = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap newImg4 = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int y = 0; y < openImg.Height; y++)
            {
                for (int x = 0; x < openImg.Width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color RGB = openImg.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue                        
                    int invR = Convert.ToInt32(RGB.R);
                    int invG = Convert.ToInt32(RGB.G);
                    int invB = Convert.ToInt32(RGB.B);
                    int gray = (invR + invG + invB) / 3;
                    Color newvalue1 = Color.FromArgb(gray, gray, gray);
                    Color newvalue2 = Color.FromArgb(invR, invR, invR);
                    Color newvalue3 = Color.FromArgb(invG, invG, invG);
                    Color newvalue4 = Color.FromArgb(invB, invB, invB);

                    newImg1.SetPixel(x, y, newvalue1);
                    newImg2.SetPixel(x, y, newvalue2);
                    newImg3.SetPixel(x, y, newvalue3);
                    newImg4.SetPixel(x, y, newvalue4);
                }
            }

            pictureBox1.Image = newImg1;
            pictureBox2.Image = newImg2;
            pictureBox3.Image = newImg3;
            pictureBox4.Image = newImg4;

        }

        //(2)Smooth Filter
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = false; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "Sourse"; label2.Text = "Mean";
            label3.Text = "Median";

            int threshold = 30;
            int width = openImg.Width;
            int height = openImg.Height;
            //第一小題 Mean Filter 
            //使原始的影像符合尺吋定義以及x,y點的位置((0,0)為矩陣左上角的座標)
            BitmapData originImageData = openImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //創立新的bitmap存放濾波後的圖 (疑問:Format24bppRgb)
            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData newImageData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //取得或設定點陣圖中第一個像素資料的位址。這也可以視為點陣圖中第一條掃描線。
            IntPtr intPtrN = newImageData.Scan0;
            //取得影像資料的起始位置
            IntPtr intPtr = originImageData.Scan0;
            // to advance from one row in your rectangle to the same relative position in the next row means advancing by the width of your imag
            int size = originImageData.Stride * height;

            byte[] oriBytes = new byte[size];
            byte[] newBytes = new byte[size];

            Marshal.Copy(intPtr, oriBytes, 0, size);
            //先複製一份一模一樣的數據到濾波模組中
            Marshal.Copy(intPtr, newBytes, 0, size);
            int[] mask = new int[9];

            int k = 3;//rgb三個存取位址
            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {
                    //因為題目要求的filter為方陣，以每3個pixel為間隔。
                    mask[0] = oriBytes[y * originImageData.Stride + x * k];
                    mask[1] = oriBytes[y * originImageData.Stride + x * k + 3];
                    mask[2] = oriBytes[y * originImageData.Stride + x * k + 6];

                    mask[3] = oriBytes[(y + 1) * originImageData.Stride + x * k];
                    mask[4] = oriBytes[(y + 1) * originImageData.Stride + x * k + 3];
                    mask[5] = oriBytes[(y + 1) * originImageData.Stride + x * k + 6];

                    mask[6] = oriBytes[(y + 2) * originImageData.Stride + x * k];
                    mask[7] = oriBytes[(y + 2) * originImageData.Stride + x * k + 3];
                    mask[8] = oriBytes[(y + 2) * originImageData.Stride + x * k + 6];

                    int mean = (mask[0] + mask[1] + mask[2] + mask[3] + mask[5] + mask[6] + mask[7] + mask[8]) / 8;

                    //取絕對值重要(取一閥值大於閥值才進行運算)
                    if (Math.Abs(mask[4] - mean) > threshold)
                    {
                        //newImageData.Stride 是等於 oriImageData.Stride 的
                        newBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)mean;
                        newBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)mean;
                        newBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)mean;
                    }
                }
            }
            Marshal.Copy(newBytes, 0, intPtrN, size);
            openImg.UnlockBits(originImageData);
            newImage.UnlockBits(newImageData);

            pictureBox2.Image = newImage;

            //第二小題 Median Filter
            Bitmap secImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData secImageData = secImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //取得或設定點陣圖中第一個像素資料的位址。這也可以視為點陣圖中第一條掃描線。
            IntPtr secintPtrN = secImageData.Scan0;

            byte[] secBytes = new byte[size];
            //先複製一份一模一樣的數據到濾波模組中
            Marshal.Copy(intPtr, secBytes, 0, size);
            int[] mask2 = new int[9];

            int j = 3;
            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {
                    //因為題目要求的filter為方陣，以每3個pixel為間隔。
                    mask[0] = oriBytes[y * originImageData.Stride + x * j];
                    mask[1] = oriBytes[y * originImageData.Stride + x * j + 3];
                    mask[2] = oriBytes[y * originImageData.Stride + x * j + 6];

                    mask[3] = oriBytes[(y + 1) * originImageData.Stride + x * j];
                    mask[4] = oriBytes[(y + 1) * originImageData.Stride + x * j + 3];
                    mask[5] = oriBytes[(y + 1) * originImageData.Stride + x * j + 6];

                    mask[6] = oriBytes[(y + 2) * originImageData.Stride + x * j];
                    mask[7] = oriBytes[(y + 2) * originImageData.Stride + x * j + 3];
                    mask[8] = oriBytes[(y + 2) * originImageData.Stride + x * j + 6];

                    Array.Sort(mask);
                    int median = mask[4];

                    //secImageData.Stride 是等于 oriImageData.Stride 的
                    secBytes[(y + 1) * originImageData.Stride + x * j + 3] = (byte)median;
                    secBytes[(y + 1) * originImageData.Stride + x * j + 4] = (byte)median;
                    secBytes[(y + 1) * originImageData.Stride + x * j + 5] = (byte)median;

                }
            }
            Marshal.Copy(secBytes, 0, secintPtrN, size);
            secImage.UnlockBits(secImageData);

            pictureBox3.Image = secImage;



        }

        //(3)Histogram Equalization
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = false; pictureBox4.Visible = false;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = true; chart2.Visible = true;

            label1.Text = "Original"; label2.Text = "Result";
            label3.Text = "Histogram of Original"; label4.Text = "Histogram of Result";

            int height = openImg.Height;
            int width = openImg.Width;

            //一維的數組(256)個元素
            double[] numb = new double[256];
            double[] ratio = new double[256];
            double[] numbs = new double[256];


            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            //計算強度r的pixel有幾個

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelRGB = openImg.GetPixel(i, j);
                    int gray = Math.Abs((pixelRGB.R + pixelRGB.G + pixelRGB.B) / 3);
                    numb[gray]++;
                }
            }

            for (int k = 0; k < 256; k++)
            {
                double value = numb[k];
                double rate = value / (height * width);
                ratio[k] = rate;
            }

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double densitySum = 0;
                    Color value = openImg.GetPixel(i, j);
                    for (int k = 0; k <= value.R; k++)
                    {
                        densitySum += ratio[k];
                    }
                    //(L-1)到強度r的頻率相加
                    byte s = (byte)Math.Abs(Math.Truncate(255 * densitySum));

                    Color newValue = Color.FromArgb(s, s, s);
                    newImage.SetPixel(i, j, newValue);

                    numbs[s]++;
                }
            }

            pictureBox2.Image = newImage;

            // 利用Chat來產生長方圖
            for (int z = 0; z < 256; z++)
            {
                chart1.Series[0].Points.AddXY(z, numb[z]);
                chart2.Series[0].Points.AddXY(z, numbs[z]);
            }

        }


        //(4)A user-defined thresholding
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = true; trackBar1.Visible = true;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "Source"; label2.Text = "Result";
            label5.Text = "Set the threshold t";



            int height = openImg.Height;
            int width = openImg.Width;
            //一維的數組(256)個元素

            trackBar1.Maximum = 255; trackBar1.Minimum = 0;
            trackBar1.TickFrequency = 10; trackBar1.LargeChange = 3; trackBar1.SmallChange = 3;
            trackBar1.Size = new Size(224, 45);


            int threshold = trackBar1.Value;
            double[] numb = new double[256];
            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelRGB = openImg.GetPixel(i, j);
                    int gray = (pixelRGB.R + pixelRGB.G + pixelRGB.B) / 3;

                    if (gray >= threshold)
                        gray = 255;
                    else
                        gray = 0;

                    Color newValue = Color.FromArgb(gray, gray, gray);
                    newImage.SetPixel(i, j, newValue);
                }
            }

            pictureBox2.Image = newImage;
        }

        //(5)Sobel edge detection (vertical, horizontal, and  combined)
        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "Source"; label2.Text = "Vertical";
            label3.Text = "Horizontal"; label4.Text = "Combined";

            int threshold = 30;
            int width = openImg.Width;
            int height = openImg.Height;

            //Vertical

            BitmapData originImageData = openImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Bitmap newImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData newImageData = newImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);


            IntPtr intPtrN = newImageData.Scan0;
            IntPtr intPtr = originImageData.Scan0;

            int size = originImageData.Stride * height;

            byte[] oriBytes = new byte[size];
            byte[] newBytes = new byte[size];

            //從 Unmanaged 記憶體指標將資料複製到 Managed 8 位元不帶正負號的整數 (Unsigned Integer) 陣列。
            Marshal.Copy(intPtr, oriBytes, 0, size);
            Marshal.Copy(intPtr, newBytes, 0, size);
            int[] mask = new int[9];

            int k = 3;
            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {

                    mask[0] = oriBytes[y * originImageData.Stride + x * k];
                    mask[1] = oriBytes[y * originImageData.Stride + x * k + 3];
                    mask[2] = oriBytes[y * originImageData.Stride + x * k + 6];

                    mask[3] = oriBytes[(y + 1) * originImageData.Stride + x * k];
                    mask[4] = oriBytes[(y + 1) * originImageData.Stride + x * k + 3];
                    mask[5] = oriBytes[(y + 1) * originImageData.Stride + x * k + 6];

                    mask[6] = oriBytes[(y + 2) * originImageData.Stride + x * k];
                    mask[7] = oriBytes[(y + 2) * originImageData.Stride + x * k + 3];
                    mask[8] = oriBytes[(y + 2) * originImageData.Stride + x * k + 6];


                    int gx = (mask[6] + 2 * mask[7] + mask[8]) - (mask[0] + 2 * mask[1] + mask[2]);

                    if (Math.Abs(mask[4] - gx) > threshold)
                    {

                        newBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)gx;
                        newBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)gx;
                        newBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)gx;
                    }
                }
            }

            Marshal.Copy(newBytes, 0, intPtrN, size);
            openImg.UnlockBits(originImageData);
            newImg.UnlockBits(newImageData);
            pictureBox2.Image = newImg;

            //Horizontal

            Bitmap secImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData secImageData = secImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr secPtrN = secImageData.Scan0;

            byte[] secBytes = new byte[size];

            Marshal.Copy(intPtr, secBytes, 0, size);

            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {

                    mask[0] = oriBytes[y * originImageData.Stride + x * k];
                    mask[1] = oriBytes[y * originImageData.Stride + x * k + 3];
                    mask[2] = oriBytes[y * originImageData.Stride + x * k + 6];

                    mask[3] = oriBytes[(y + 1) * originImageData.Stride + x * k];
                    mask[4] = oriBytes[(y + 1) * originImageData.Stride + x * k + 3];
                    mask[5] = oriBytes[(y + 1) * originImageData.Stride + x * k + 6];

                    mask[6] = oriBytes[(y + 2) * originImageData.Stride + x * k];
                    mask[7] = oriBytes[(y + 2) * originImageData.Stride + x * k + 3];
                    mask[8] = oriBytes[(y + 2) * originImageData.Stride + x * k + 6];

                    int gy = (mask[2] + 2 * mask[5] + mask[8]) - (mask[0] + 2 * mask[3] + mask[6]);

                    secBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)gy;
                    secBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)gy;
                    secBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)gy;

                }
            }

            Marshal.Copy(secBytes, 0, secPtrN, size);
            secImg.UnlockBits(secImageData);
            pictureBox3.Image = secImg;

            // Combined

            Bitmap thrImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData thrImageData = thrImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr thrPtrN = thrImageData.Scan0;

            byte[] thrBytes = new byte[size];

            Marshal.Copy(intPtr, thrBytes, 0, size);

            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {

                    mask[0] = oriBytes[y * originImageData.Stride + x * k];
                    mask[1] = oriBytes[y * originImageData.Stride + x * k + 3];
                    mask[2] = oriBytes[y * originImageData.Stride + x * k + 6];

                    mask[3] = oriBytes[(y + 1) * originImageData.Stride + x * k];
                    mask[4] = oriBytes[(y + 1) * originImageData.Stride + x * k + 3];
                    mask[5] = oriBytes[(y + 1) * originImageData.Stride + x * k + 6];

                    mask[6] = oriBytes[(y + 2) * originImageData.Stride + x * k];
                    mask[7] = oriBytes[(y + 2) * originImageData.Stride + x * k + 3];
                    mask[8] = oriBytes[(y + 2) * originImageData.Stride + x * k + 6];

                    int M = Math.Abs((mask[6] + 2 * mask[7] + mask[8]) - (mask[0] + 2 * mask[1] + mask[2])) + Math.Abs((mask[2] + 2 * mask[5] + mask[8]) - (mask[0] + 2 * mask[3] + mask[6]));

                    thrBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)M;
                    thrBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)M;
                    thrBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)M;

                }
            }

            Marshal.Copy(thrBytes, 0, thrPtrN, size);
            thrImg.UnlockBits(thrImageData);
            pictureBox4.Image = thrImg;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                thrImg.Save(sfd.FileName);
            }

        }

        //(6)Threshold the result of (5) to binary image and  overlap on the original image
        private void button8_Click(object sender, EventArgs e)
        {
            //Sobel edge detection
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "The result of (5)"; label2.Text = "The result after thresholding";
            label3.Text = "The green color of Binary image"; label4.Text = "Overlap on the original image by green color";

            int height = openImg.Height;
            int width = openImg.Width;


            BitmapData originImageData = openImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Bitmap newImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData thrImageData = newImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int size = originImageData.Stride * height;

            IntPtr intPtrN = thrImageData.Scan0;
            IntPtr intPtr = originImageData.Scan0;

            byte[] newBytes = new byte[size];
            byte[] oriBytes = new byte[size];

            Marshal.Copy(intPtr, newBytes, 0, size);
            Marshal.Copy(intPtr, oriBytes, 0, size);

            int[] mask = new int[9];
            int k = 3;
            for (int y = 0; y < height - 2; y++)
            {
                for (int x = 0; x < width - 2; x++)
                {

                    mask[0] = oriBytes[y * originImageData.Stride + x * k];
                    mask[1] = oriBytes[y * originImageData.Stride + x * k + 3];
                    mask[2] = oriBytes[y * originImageData.Stride + x * k + 6];

                    mask[3] = oriBytes[(y + 1) * originImageData.Stride + x * k];
                    mask[4] = oriBytes[(y + 1) * originImageData.Stride + x * k + 3];
                    mask[5] = oriBytes[(y + 1) * originImageData.Stride + x * k + 6];

                    mask[6] = oriBytes[(y + 2) * originImageData.Stride + x * k];
                    mask[7] = oriBytes[(y + 2) * originImageData.Stride + x * k + 3];
                    mask[8] = oriBytes[(y + 2) * originImageData.Stride + x * k + 6];

                    int M = Math.Abs((mask[6] + 2 * mask[7] + mask[8]) - (mask[0] + 2 * mask[1] + mask[2])) + Math.Abs((mask[2] + 2 * mask[5] + mask[8]) - (mask[0] + 2 * mask[3] + mask[6]));

                    newBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)M;
                    newBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)M;
                    newBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)M;

                }
            }

            Marshal.Copy(newBytes, 0, intPtrN, size);
            openImg.UnlockBits(originImageData);
            newImg.UnlockBits(thrImageData);
            pictureBox1.Image = newImg;


            //一維的數組(256)個元素
            int threshold = 150;
            double[] numb = new double[256];

            Bitmap secImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    Color pixelRGB = newImg.GetPixel(i, j);
                    int gray = (pixelRGB.R + pixelRGB.G + pixelRGB.B) / 3;

                    if (gray >= threshold)
                        gray = 255;
                    else
                        gray = 0;

                    Color newValue = Color.FromArgb(gray, gray, gray);
                    secImage.SetPixel(i, j, newValue);
                }
            }

            pictureBox2.Image = secImage;

            //取綠色的圖
            Bitmap thrImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊
                    Color gRGB = secImage.GetPixel(x, y);
                    int invR = Convert.ToInt32(gRGB.R);
                    int invG = Convert.ToInt32(gRGB.G);
                    int invB = Convert.ToInt32(gRGB.B);

                    Color green = Color.FromArgb(0, invG, 0);
                    thrImage.SetPixel(x, y, green);
                }
            }
            pictureBox3.Image = thrImage;

            //將 secImage 與 newImage 重疊
            Bitmap fouImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color oriRGB = openImg.GetPixel(i, j);
                    int oriR = Convert.ToInt32(oriRGB.R);
                    int oriG = Convert.ToInt32(oriRGB.G);
                    int oriB = Convert.ToInt32(oriRGB.B);

                    Color thrRGB = thrImage.GetPixel(i, j);
                    int thrR = Convert.ToInt32(thrRGB.R);
                    int thrG = Convert.ToInt32(thrRGB.G);
                    int thrB = Convert.ToInt32(thrRGB.B);

                    Color fouRGB = fouImage.GetPixel(i, j);

                    if (thrG < 255 && thrG == 0)
                    {
                        fouRGB = Color.FromArgb(oriR, oriG, oriB);
                        fouImage.SetPixel(i, j, fouRGB);
                    }
                    else
                    {
                        fouRGB = Color.FromArgb(0, thrG, 0);
                        fouImage.SetPixel(i, j, fouRGB);
                    }
                }
            }
            pictureBox4.Image = fouImage;
        }

        int[,] A1 = new int[4, 2];
        int[,] A2 = new int[4, 2];
        int click_time01 = 0;
        int click_time02 = 0;
        Bitmap problem_07_01;
        Bitmap problem_07_02;
        



        private void problem_07_01_MouseClick(object sender, MouseEventArgs e)
        {

            if (A1[click_time01, 0] == 0 && click_time01 < 4)
            {
                A1[click_time01, 0] = e.X;
                A1[click_time01, 1] = e.Y;
                if (click_time01 < 3) click_time01++;

            }
            else { MessageBox.Show("Enough"); }
        }


        private void PB_solution7_02_MouseClick(object sender, MouseEventArgs e)
        {
            if (A2[click_time02, 0] == 0 && click_time02 < 4)
            {
                A2[click_time02, 0] = e.X;
                A2[click_time02, 1] = e.Y;
                if (click_time02 < 3) click_time02++;
            }
            else { MessageBox.Show("Enough"); }

            button12.Visible = true;
        }
        
        
        public void button12_Click(object sender, EventArgs e)
        {
            
            //平移至相同座標
            var d_X = 0; var d_Y = 0;
            d_X = A1[0, 0] - A2[0, 0];
            d_Y = A1[0, 1] - A2[0, 1];
            //另一個新的A2'陣列
            int[,] A2p = new int[4, 2];
            int[,] D = { { d_X, d_Y }, { d_X, d_Y }, { d_X, d_Y }, { d_X, d_Y } };

            //MessageBox.Show(A1[0, 0].ToString() + A1[0, 1].ToString());
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    A2p[i, j] = A2[i, j] + D[i, j];
                }
            }
            //MessageBox.Show(A2p[i, j].ToString());
            var origin = new Point(A1[0, 0], A1[0, 1]);
            var p1 = new Point(A1[1, 0], A1[1, 1]);
            var p2 = new Point(A2p[1, 0], A2p[1, 1]);
            var angle1 = Math.Atan2(p1.Y - origin.Y, p1.X - origin.X);
            var angle2 = Math.Atan2(p2.Y - origin.Y, p2.X - origin.X);
            var angle3 = angle1 - angle2;
            var Rotatin_angle = angle3 * (180 / Math.PI);
            label2.Text = "Rotatin_angle:" + Rotatin_angle.ToString();

            


            //找比例scaling
            var dis_A1_x = Math.Sqrt(Math.Pow(A1[1, 0] - A1[0, 0], 2) + Math.Pow(A1[1, 1] - A1[0, 1], 2));
            var dis_A2_x = Math.Sqrt(Math.Pow(A2[1, 0] - A2[0, 0], 2) + Math.Pow(A2[1, 1] - A2[0, 1], 2));    
            var scaling_factor_x = dis_A1_x / dis_A2_x;
            label3.Text = "scaling_factor_x:" + scaling_factor_x.ToString();


            var dis_A1_y = Math.Sqrt(Math.Pow(A1[3, 0] - A1[1, 0], 2) + Math.Pow(A1[3, 1] - A1[1, 1], 2));
            var dis_A2_y = Math.Sqrt(Math.Pow(A2[3, 0] - A2[1, 0], 2) + Math.Pow(A2[3, 1] - A2[1, 1], 2));
            var scaling_factor_y = dis_A1_y / dis_A2_y;
            label4.Text = "scaling_factor_y ： " + scaling_factor_y;
        }
    
        

        //(7)Image registration
        public void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label5.Visible = false; trackBar1.Visible = false;
            chart1.Visible = false; chart2.Visible = false;

            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                openImg = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = openImg;    
            }

            openFileDialog2.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";

            Bitmap secImg;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                secImg = new Bitmap(openFileDialog2.FileName);
                pictureBox1.Image = secImg;
            }

            int degree = Rotatin_angle;

            int width = openImg.Width;
            int height = openImg.Height;

            double nw = (int)(Math.Abs(width * Math.Cos(Math.PI * (degree / 180))) + Math.Abs(height * Math.Sin(Math.PI * (degree / 180))) + 0.5);
            double nh = (int)(Math.Abs(width * Math.Sin(Math.PI * (degree / 180))) + Math.Abs(height * Math.Cos(Math.PI * (degree / 180))) + 0.5);

            Bitmap newImg = new Bitmap((int)nw, (int)nh, PixelFormat.Format24bppRgb);

            for (int y1 = 0; y1 < nh; y1++)
            {
                for (int x1 = 0; x1 < nw; x1++)
                {
                    double x = x1 * Math.Cos(Math.PI * (degree / 180)) + y1 * Math.Sin(Math.PI * (degree / 180)) - (nw - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) - (nh - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) + (width - 1) / 2.0;
                    double y = -x1 * Math.Sin(Math.PI * (degree / 180)) + y1 * Math.Cos(Math.PI * (degree / 180)) + (nw - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) - (nh - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) + (height - 1) / 2.0;
                    if (-0.001 <= x & x <= (width - 1) & -0.001 <= y & y <= (height - 1))
                    {
                        Color RGB = new Color();

                        int a1 = (int)x;
                        int b1 = (int)y;
                        int a2 = (int)Math.Ceiling(x);
                        int b2 = (int)y;
                        int a3 = (int)x;
                        int b3 = (int)Math.Ceiling(y);
                        int a4 = (int)Math.Ceiling(x);
                        int b4 = (int)Math.Ceiling(y);

                        double xa13 = x - a1;
                        double xa24 = a2 - x;
                        double yb12 = y - b1;
                        double yb34 = b3 - y;

                        if (xa13 != 0 & xa24 != 0 & yb12 != 0 & yb34 != 0)
                        {//对应回原图是非整数坐标，双线性插值。
                            byte R1 = openImg.GetPixel(a1, b1).R;
                            byte G1 = openImg.GetPixel(a1, b1).G;
                            byte B1 = openImg.GetPixel(a1, b1).B;
                            byte R2 = openImg.GetPixel(a2, b2).R;
                            byte G2 = openImg.GetPixel(a2, b2).G;
                            byte B2 = openImg.GetPixel(a2, b2).B;
                            byte R3 = openImg.GetPixel(a3, b3).R;
                            byte G3 = openImg.GetPixel(a3, b3).G;
                            byte B3 = openImg.GetPixel(a3, b3).B;
                            byte R4 = openImg.GetPixel(a4, b4).R;
                            byte G4 = openImg.GetPixel(a4, b4).G;
                            byte B4 = openImg.GetPixel(a4, b4).B;

                            byte R = (byte)((R1 * xa24 + R2 * xa13) * yb34 + (R3 * xa24 + R4 * xa13) * yb12);
                            byte G = (byte)((G1 * xa24 + G2 * xa13) * yb34 + (G3 * xa24 + G4 * xa13) * yb12);
                            byte B = (byte)((B1 * xa24 + B2 * xa13) * yb34 + (B3 * xa24 + B4 * xa13) * yb12);

                            RGB = Color.FromArgb(R, G, B);
                        }
                        else
                        {//对应回原图是整数坐标,直接取Pixel。
                            RGB = openImg.GetPixel(a1, b1);
                        }
                        newImg.SetPixel(x1, y1, RGB);



                    }
                }
            }


            pictureBox3.Image = newImg;

        }
       

        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false;
            }
            if (pictureBox2.Image != null)
            {
                pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false;
            }
            if (pictureBox3.Image != null)
            {
                pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false;
            }
            if (pictureBox4.Image != null)
            {
                pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null; pictureBox1.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false;
            }
        }
    }

}
