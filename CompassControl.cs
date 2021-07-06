using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public class CompassControl:Control
    {
        public List<string> Navigation;
        public Point mousePos;
        public CompassControl():base()
        {
            this.Size = new System.Drawing.Size(100,100);
            this.BackColor = Color.Gray;
            this.Paint += CompassControl_Paint;
            this.Navigation = new List<string>() { 
                "I",
                "II",
                "III",
                "IV"
            };
            this.MouseClick += CompassControl_MouseClick;
            
        }

        private void CompassControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.mousePos = new Point(e.X, e.Y);
            this.Invalidate();
        }


        private void CompassControl_Paint(object sender, PaintEventArgs e)
        {
            var Graphics = this.CreateGraphics();
            Font font = new Font("Arial",12,FontStyle.Bold);

            Graphics.DrawString(this.Navigation[0],font,Brushes.Blue,(float)(this.Width/2-6),0);
            Graphics.DrawString(this.Navigation[1],font,Brushes.Blue,(float)(this.Width-12),this.Height/2-6);
            Graphics.DrawString(this.Navigation[2],font,Brushes.Blue,(float)(this.Width/2-12),this.Height-14);
            Graphics.DrawString(this.Navigation[3],font,Brushes.Blue,0,this.Height/2-12);


            Graphics.FillEllipse(Brushes.White,new Rectangle(this.Width/6,this.Height/6,this.Width- this.Width / 3,this.Height- this.Height/3));
            if (new Rectangle(this.mousePos, new Size(1, 1)).IntersectsWith(new Rectangle(0, 12, 12, this.Width - 24))) {
                Graphics.FillClosedCurve(Brushes.Blue,new Point[]{ 
                    new Point(this.Width/2,this.Height/2-6),
                    new Point(this.Width/2,this.Height/2+6),
                    new Point(12,this.Height/2)
                });
            }
            if (new Rectangle(this.mousePos, new Size(1, 1)).IntersectsWith(new Rectangle(12, 0, this.Width-24, 12)))
            {
                Graphics.FillClosedCurve(Brushes.Blue, new Point[]{
                    new Point(this.Width/2-6,this.Height/2),
                    new Point(this.Width/2+6,this.Height/2),
                    new Point(this.Width/2,12)
                });
            }
            if (new Rectangle(this.mousePos, new Size(1, 1)).IntersectsWith(new Rectangle(12, this.Height-24, this.Height-12,12)))
            {
                Graphics.FillClosedCurve(Brushes.Blue, new Point[]{
                    new Point(this.Width/2-6,this.Height/2),
                    new Point(this.Width/2+6,this.Height/2),
                    new Point(this.Width/2,this.Height-12)
                });
            }
            if (new Rectangle(this.mousePos, new Size(1, 1)).IntersectsWith(new Rectangle(this.Width-12, 12, 12, this.Height-24)))
            {
                Graphics.FillClosedCurve(Brushes.Blue, new Point[]{
                    new Point(this.Width/2,this.Height/2-6),
                    new Point(this.Width/2,this.Height/2+6),
                    new Point(this.Width-12,this.Height/2)
                });
            }



        }
    }
}
