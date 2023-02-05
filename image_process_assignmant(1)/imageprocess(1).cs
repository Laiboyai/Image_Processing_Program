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
            label4.Visible = false; label5.Visible = false; label6.Visible = false;
            label7.Visible = false; label8.Visible = false; label9.Visible = false;
            trackBar1.Visible = false; trackBar2.Visible = false;
            chart1.Visible = false;    chart2.Visible = false;
            button12.Visible = false;
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

            label1.Text = "Sourse"; label2.Text = "Mean Filter";
            label3.Text = "Median Filter";

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

            label1.Text = "Original"; label2.Text = "Result After Histogram Equalization";
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
            label1.Visible = true; label2.Visible = true; label3.Visible = false;
            label4.Visible = false; label5.Visible = true; trackBar1.Visible = true;
            chart1.Visible = false; chart2.Visible = false;

            label1.Text = "Source"; label2.Text = "The Result of Binary Image";
            label5.Text = "Set the Threshold t";



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


                    int gx = Math.Abs((mask[6] + 2 * mask[7] + mask[8]) - (mask[0] + 2 * mask[1] + mask[2]));

                    
                     newBytes[(y + 1) * originImageData.Stride + x * k + 3] = (byte)gx;
                     newBytes[(y + 1) * originImageData.Stride + x * k + 4] = (byte)gx;
                     newBytes[(y + 1) * originImageData.Stride + x * k + 5] = (byte)gx;
                    
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

                    int gy = Math.Abs((mask[2] + 2 * mask[5] + mask[8]) - (mask[0] + 2 * mask[3] + mask[6]));

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
            
        }

        //(6)Threshold the result of (5) to binary image and  overlap on the original image
        private void button8_Click(object sender, EventArgs e)
        {
            //Sobel edge detection
            pictureBox1.Visible = true; pictureBox2.Visible = true;
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true;
            label4.Visible = true; label9.Visible = true; trackBar2.Visible = true; 

            label1.Text = "The Result of (5)"; label2.Text = "The Result After Thresholding";
            label3.Text = "The Green Color of Binary Image"; label4.Text = "Overlap on the Original Image by Green color";

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
            trackBar2.Maximum = 255; trackBar2.Minimum = 15;
            trackBar2.TickFrequency = 10; trackBar2.LargeChange = 3; trackBar2.SmallChange = 3;
            trackBar2.Size = new Size(224, 45);

            label9.Text = "Set the Threshold t";

            int threshold = trackBar2.Value;           
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

        //(7)Image registration
        Bitmap secImg;

        private void button9_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true;

            label1.Visible = true; label2.Visible = true; 
            

            label1.Text = "Image A";
            label2.Text = "Image B";

            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            // 選擇我們需要開檔的類型
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openImg = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = openImg;

            }

            openFileDialog3.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";


            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                Bitmap secondImg = new Bitmap(openFileDialog3.FileName);
                secImg = secondImg;
                pictureBox2.Image = secondImg;
            }

            button12.Visible = true;
        }

        int[,] A = new int[4, 2];
        int[,] B = new int[4, 2];
        int count01 = 0;
        int count02 = 0;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs point)
        {
            if (A[count01, 0] == 0 && count01 < 4)
            {
                A[count01, 0] = point.X;
                A[count01, 1] = point.Y;
                if (count01 < 3)
                    count01++;
            }
            else
            {
                MessageBox.Show("enough");
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

            if (B[count02, 0] == 0 && count02 < 4)
            {
                B[count02, 0] = e.X;
                B[count02, 1] = e.Y;
                if (count02 < 3)
                    count02++;
            }
            else
            {
                MessageBox.Show("Enough");
            }
        }


        public void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = true; 
            pictureBox3.Visible = true; pictureBox4.Visible = true;
            label1.Visible = true;  label2.Visible = true; label3.Visible = true;
            label6.Visible = true;  label7.Visible = true; label8.Visible = true;

            label3.Text = "The result of Image registration";

            var d_X = 0; var d_Y = 0;
            d_X = A[0, 0] - B[0, 0];
            d_Y = A[0, 1] - B[0, 1];
            //另一個新的A2'陣列
            //另一個新的 "B" 陣列
            int[,] NewB = new int[4, 2];
            int[,] difference = { { d_X, d_Y }, { d_X, d_Y }, { d_X, d_Y }, { d_X, d_Y } };

            //平移至相同座標系
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    NewB[i, j] = B[i, j] + difference[i, j];
                }
            }

            //定義各點座標
            Point origin = new Point(A[0, 0], A[0, 1]);
            Point p1 = new Point(A[1, 0], A[1, 1]);
            Point p2 = new Point(NewB[1, 0], NewB[1, 1]);

            //找出A要旋轉多少角度才能到達B
            double angle1 = Math.Atan2(p1.Y - origin.Y, p1.X - origin.X);
            double angle2 = Math.Atan2(p2.Y - origin.Y, p2.X - origin.X);
            double angle3 = angle1 - angle2;
            double Rotatin_angle = angle3 * (180 / Math.PI);
            double rotangle = -1 * Rotatin_angle;
            label6.Text = "Rotatin angle ： " + rotangle.ToString();

            //找比例scaling
            double dis_A1_x = Math.Sqrt(Math.Pow(A[1, 0] - A[0, 0], 2) + Math.Pow(A[1, 1] - A[0, 1], 2));
            double dis_A2_x = Math.Sqrt(Math.Pow(B[1, 0] - B[0, 0], 2) + Math.Pow(B[1, 1] - B[0, 1], 2));
            double scalfactor_x = dis_A1_x / dis_A2_x;

            double dis_A1_y = Math.Sqrt(Math.Pow(A[3, 0] - A[1, 0], 2) + Math.Pow(A[3, 1] - A[1, 1], 2));
            double dis_A2_y = Math.Sqrt(Math.Pow(B[3, 0] - B[1, 0], 2) + Math.Pow(B[3, 1] - B[1, 1], 2));
            double scalfactor_y = dis_A1_y / dis_A2_y;

            double scalfactor_s = (scalfactor_x + scalfactor_y) / 2;
            label7.Text = "Scaling factor s ： " + scalfactor_s.ToString();


            // 做雙線性內插法

            int width = secImg.Width;
            int height = secImg.Height;
            double degree = Rotatin_angle;

            double nw = (int)((scalfactor_x) * (Math.Abs(width * Math.Cos(Math.PI * (degree / 180))) + Math.Abs(height * Math.Sin(Math.PI * (degree / 180))) + 0.5));
            double nh = (int)((scalfactor_y) * (Math.Abs(width * Math.Sin(Math.PI * (degree / 180))) + Math.Abs(height * Math.Cos(Math.PI * (degree / 180))) + 0.5));

            Bitmap thrImg = new Bitmap((int)nw, (int)nh, PixelFormat.Format24bppRgb);

            for (int y1 = 0; y1 < nh; y1++)
            {
                for (int x1 = 0; x1 < nw; x1++)
                {
                    double x = (1 / scalfactor_x) * (x1 * Math.Cos(Math.PI * (degree / 180)) + y1 * Math.Sin(Math.PI * (degree / 180)) - (nw - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) - (nh - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) + (width - 1) / 2.0);
                    double y = (1 / scalfactor_y) * (-x1 * Math.Sin(Math.PI * (degree / 180)) + y1 * Math.Cos(Math.PI * (degree / 180)) + (nw - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) - (nh - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) + (height - 1) / 2.0);
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
                        {
                            byte R1 = secImg.GetPixel(a1, b1).R;
                            byte R2 = secImg.GetPixel(a2, b2).R;
                            byte R3 = secImg.GetPixel(a3, b3).R;
                            byte R4 = secImg.GetPixel(a4, b4).R;

                            byte R = (byte)((R1 * xa24 + R2 * xa13) * yb34 + (R3 * xa24 + R4 * xa13) * yb12);

                            RGB = Color.FromArgb(R, R, R);
                        }
                        else
                        {
                            RGB = secImg.GetPixel(a1, b1);
                        }

                        thrImg.SetPixel(x1, y1, RGB);
                    }
                }
            }

            int[] pd = new int[2];
            for (int z = 0; z < thrImg.Width; z++)
            {
                for (int y = 0; y < thrImg.Height; y++)
                {
                    Color tRGB = thrImg.GetPixel(z, y);
                    if (tRGB.R > 100)
                    {
                        pd[0] = z;
                        pd[1] = y;
                        break;
                    }
                    if (pd[0] != 0) break;

                }
            }
            pictureBox3.Image = thrImg;


            double inx = Math.Round((nw / 2) - (width / 2));
            double iny = Math.Round((nh / 2) - (height / 2));
            PixelFormat format = thrImg.PixelFormat;
            Rectangle clonerect = new Rectangle(242, 218, openImg.Width + 5, openImg.Height + 5);
            Bitmap thrImgclone = thrImg.Clone(clonerect, format);

            pictureBox3.Image = thrImgclone;

            int intensity = 0;
            int numb = 0;
            for (int i = 0;i < openImg.Width ; i++ )
            {
                for (int j = 0; j < openImg.Height; j++)
                {
                    Color oRGB = openImg.GetPixel(i, j);
                    int oriR = Convert.ToInt32(oRGB.R);
                    int oriG = Convert.ToInt32(oRGB.G);
                    int oriB = Convert.ToInt32(oRGB.B);
                    int oriGray = (oriR + oriG + oriB) / 3;

                    Color tRGB = thrImgclone.GetPixel(i, j);
                    int thrR = Convert.ToInt32(tRGB.R);
                    int thrG = Convert.ToInt32(tRGB.G);
                    int thrB = Convert.ToInt32(tRGB.B);
                    int thrGray = (thrR + thrG + thrB) / 3;

                    intensity = intensity + (thrGray - oriGray);
                    numb++;
                }
            }

            double intensity_difference = intensity / numb;
            label8.Text = "Intensity Difference ： " + intensity_difference.ToString();
            
        }

        int[] vv = new int[2];

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            vv[0] = e.X;
            vv[1] = e.Y;
            string v1 = vv[0].ToString();
            string v2 = vv[1].ToString();


            MessageBox.Show(v1, v2);
        }
        
        private void button10_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null; 
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Text = null; label2.Text = null; label3.Text = null; label4.Text = null; label5.Text = null;
                label6.Text = null; label7.Text = null; label8.Text = null; label9.Text = null;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false; trackBar2.Visible = false;
            }
            if (pictureBox2.Image != null)
            {
                pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Text = null; label2.Text = null; label3.Text = null; label4.Text = null; label5.Text = null;
                label6.Text = null; label7.Text = null; label8.Text = null; label9.Text = null;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false; trackBar2.Visible = false;
            }
            if (pictureBox3.Image != null)
            {
                pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Text = null; label2.Text = null; label3.Text = null; label4.Text = null; label5.Text = null;
                label6.Text = null; label7.Text = null; label8.Text = null; label9.Text = null;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false; trackBar2.Visible = false;
            }
            if (pictureBox4.Image != null)
            {
                pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null;
                pictureBox1.Visible = false; pictureBox2.Visible = false; pictureBox3.Visible = false; pictureBox4.Visible = false;
                label1.Text = null; label2.Text = null; label3.Text = null; label4.Text = null; label5.Text = null;
                label6.Text = null; label7.Text = null; label8.Text = null; label9.Text = null;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false;
                chart1.Visible = false; chart2.Visible = false; trackBar1.Visible = false; trackBar2.Visible = false;
            }
            
        }

      
    }
}
