using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://stackoverflow.com/questions/32600523/how-do-i-move-a-graphics-rectangle-with-my-keys

namespace WindowsFormPractice
{
    public partial class Form1 : Form
    {
        private Rectangle _SelectedArea;
        private Rectangle _SelectedArea2;
        private Rectangle _SelectedArea3;
        private Rectangle _SelectedArea4;
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 750;
            _SelectedArea = new Rectangle(0, 0, 50, 50);
            _SelectedArea2 = new Rectangle(930, 0, 50, 50);
            _SelectedArea3 = new Rectangle(930, 645, 50, 50);
            _SelectedArea4 = new Rectangle(0, 645, 50, 50);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!e.Handled)
            {
                switch (e.KeyData)
                {
                    case Keys.Down:
                        _SelectedArea.Offset(0, 5);
                        _SelectedArea2.Offset(0, 5);
                        _SelectedArea3.Offset(0, -5);
                        _SelectedArea4.Offset(0, -5);
                        break;

                    case Keys.Up:
                        _SelectedArea.Offset(0, -5);
                        _SelectedArea2.Offset(0, -5);
                        _SelectedArea3.Offset(0, 5);
                        _SelectedArea4.Offset(0, 5);
                        break;

                    case Keys.Left:
                        _SelectedArea.Offset(-5, 0);
                        _SelectedArea2.Offset(5, 0);
                        _SelectedArea3.Offset(5, 0);
                        _SelectedArea4.Offset(-5, 0);
                        break;

                    case Keys.Right:
                        _SelectedArea.Offset(5, 0);
                        _SelectedArea2.Offset(-5, 0);
                        _SelectedArea3.Offset(-5, 0);
                        _SelectedArea4.Offset(5, 0);
                        break;
                }

                e.Handled = true;
                // The Invalidate() call causes the control to be redrawn.
                // Check https://msdn.microsoft.com/en-us/library/598t492a.aspx
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var pen = new Pen(Color.Red))
            using (var brush = new HatchBrush(HatchStyle.Percent10, Color.Blue, Color.Transparent))
            {
                e.Graphics.FillRectangle(new HatchBrush(HatchStyle.Percent10, Color.Blue, Color.Transparent), _SelectedArea);
                e.Graphics.DrawRectangle(new Pen(Color.Blue), _SelectedArea);

                e.Graphics.FillRectangle(new HatchBrush(HatchStyle.Percent50, Color.Red, Color.Transparent), _SelectedArea2);
                e.Graphics.DrawRectangle(new Pen(Color.Black), _SelectedArea2);

                e.Graphics.FillRectangle(new SolidBrush(Color.Coral), _SelectedArea3);
                e.Graphics.DrawRectangle(new Pen(Color.OrangeRed), _SelectedArea3);

                e.Graphics.FillRectangle(new LinearGradientBrush(new Point(0, 10), new Point(10, 20), Color.Green, Color.Gray), _SelectedArea4);
                e.Graphics.DrawRectangle(pen, _SelectedArea4);
            }
        }
    }
}
