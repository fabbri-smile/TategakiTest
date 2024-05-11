using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TategakiTest
{



    public partial class Form1 : Form
    {
        const string DRAW_STRING = "「縦書き」文字列(1a)、句読点はどう出るか。";

        public Form1()
        {
            InitializeComponent();
        }

        // 参照 : https://dobon.net/vb/dotnet/graphics/drawstring.html
        private Bitmap CreateVerticalTextImage(string drawString, int bitmapWidth, int bitmapHeight, bool convertToZenkaku)
        {
            // 半角 => 全角変換
            if (convertToZenkaku) drawString = StringUtil.Han2Zen(drawString);

            // 描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(bitmapWidth, bitmapHeight);

            using (Graphics g = Graphics.FromImage(canvas))                     // ImageオブジェクトのGraphicsオブジェクト
            using (Font font = new Font("@ＭＳ ゴシック", 16, FontStyle.Bold))  // Fontオブジェクト (先頭'@'は縦書き用フォント)
            using (StringFormat sf = new StringFormat())                        // StringFormatを作成
            {
                //縦書きにする
                sf.FormatFlags = StringFormatFlags.DirectionVertical;

                //文字を表示
                g.DrawString(drawString, font, Brushes.Black, 150.0F, 50.0F, sf);
            }
            return canvas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PictureBox1に縦書きテキストを表示
            pictureBox1.Image = CreateVerticalTextImage(DRAW_STRING, pictureBox1.Width, pictureBox1.Height, checkBox1.Checked);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            //PictureBox1に縦書きテキストを表示
            pictureBox1.Image = CreateVerticalTextImage(DRAW_STRING, pictureBox1.Width, pictureBox1.Height, checkBox1.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //PictureBox1に縦書きテキストを表示
            pictureBox1.Image = CreateVerticalTextImage(DRAW_STRING, pictureBox1.Width, pictureBox1.Height, checkBox1.Checked);
        }
    }
}
