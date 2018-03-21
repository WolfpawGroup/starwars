using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace starwars
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			rtb_Text.SelectAll();
			rtb_Text.SelectionAlignment = HorizontalAlignment.Center;
			rtb_Text.DeselectAll();
			panel1.BackgroundImageLayout = ImageLayout.Zoom;
		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			if(rtb_Text.Text != "") { loadImage(); }
		}

		public void loadImage()
		{
			Font fnt = new Font("Consolas", 22, FontStyle.Regular);
			Size s = TextRenderer.MeasureText(rtb_Text.Text, fnt);

			Bitmap bmp = new Bitmap(s.Width + 100, s.Height + 100);

			System.Drawing.Drawing2D.Matrix matr = new System.Drawing.Drawing2D.Matrix();
			matr.Shear(-0.5f, 0.3f);

			string str = matr.Elements[0].ToString().PadLeft(4,' ') + " - " + matr.Elements[1] + "\r\n" + matr.Elements[2].ToString().PadLeft(4, ' ') + " - " + matr.Elements[3] + "\r\n" + matr.Elements[4].ToString().PadLeft(4, ' ') + " - " + matr.Elements[5];


			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.Transform = matr;
				g.DrawString(rtb_Text.Text, fnt, Brushes.Yellow, new Point(bmp.Width / 2, 50), new StringFormat() { Alignment = StringAlignment.Center });
			}

			label1.Text = str;

			panel1.BackgroundImage = bmp;
		}
	}
}
