using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public class ZohaButton:Control
    {
        public bool isChecked = false;
        public Rectangle hitZone;
        public Point mousePoint;
        public ZohaButton():base()
        {
            this.Size = new System.Drawing.Size(150,100);
            this.Location = new System.Drawing.Point(0,0);
            this.BackColor = Color.Gray;
            base.Paint += ZohaButton_Paint;
            base.MouseClick += ZohaButton_MouseClick;
            hitZone = new Rectangle(this.Location.X+ this.Size.Width / 10, this.Location.Y+ this.Size.Height / 10, this.Width- this.Size.Width / 5, this.Height- this.Size.Height / 5);
            this.SizeChanged += ZohaButton_SizeChanged;
        }

        private void ZohaButton_SizeChanged(object sender, EventArgs e)
        {
            if (Size.Height >= Size.Width || this.Size.Height<=30 || this.Size.Width<=30) {
                this.Size = new System.Drawing.Size(150, 100);
            }
                hitZone = new Rectangle(this.Location.X + this.Size.Width/10, this.Location.Y + this.Size.Height / 10, this.Width - this.Size.Width / 5, this.Height - this.Size.Height / 5);
        }

        private void ZohaButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.mousePoint = new Point(e.X,e.Y);
            this.Invalidate();
        }

        private void ZohaButton_Paint(object sender, PaintEventArgs e)
        {
            var Graphics = this.CreateGraphics();

            int height = this.hitZone.Height;
            int width = height;


            Graphics.FillRectangle(Brushes.White,this.hitZone);
            if (new Rectangle(this.mousePoint, new Size(1, 1)).IntersectsWith(this.hitZone))
            {
                isChecked = !isChecked;
            }
                if (isChecked)
                {
                    Graphics.FillEllipse(Brushes.Green, new Rectangle(this.hitZone.X, hitZone.Y, width, height));
                }
                else {
                    Graphics.FillEllipse(Brushes.Red, new Rectangle(this.hitZone.X+this.hitZone.Width-width, this.hitZone.Y, width, height));
                }

        }
    }
}
