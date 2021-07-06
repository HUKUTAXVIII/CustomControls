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
            
        }

        private void CompassControl_Paint(object sender, PaintEventArgs e)
        {
            var Graphics = this.CreateGraphics();
            Font font = new Font("Arial",12,FontStyle.Bold);

            Graphics.DrawString(this.Navigation[0],font,Brushes.Blue,(float)(this.Width/2-6),0);
            Graphics.DrawString(this.Navigation[1],font,Brushes.Blue,(float)(this.Width-12),this.Height/2-6);
            Graphics.DrawString(this.Navigation[2],font,Brushes.Blue,(float)(this.Width/2-12),this.Height-14);
            Graphics.DrawString(this.Navigation[3],font,Brushes.Blue,0,this.Height/2-12);


            //Graphics.FillClosedCurve(Brushes.Blue,new Point[] { 
            //    new Point(0,0),
            //    new Point(0,Width),
            //    new Point(Width/2,Height/2)
            //});


            Graphics.FillEllipse(Brushes.White,new Rectangle(this.Width/6,this.Height/6,this.Width- this.Width / 3,this.Height- this.Height/3));

        }
    }
}
