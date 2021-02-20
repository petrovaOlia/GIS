using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    class Text : MapObject
    {
        public GeoPoint beginn, endd;
        string text;
        public Text(GeoPoint b, GeoPoint e, string textt, Layer obj, int pr): base(obj, pr)
        {
            text = textt;
            beginn = b;
            endd = e;
        }
    
        override public MapObject Selected(MouseEventArgs e, ref double d)
        {
            return null;
        }
       
        override public void Paint(PaintEventArgs e)
        {
            PointF b = this.layer.map.MapToScreen(this.beginn);
            PointF en = this.layer.map.MapToScreen(this.endd);
            e.Graphics.DrawString(this.text, new Font("Arial", 14f), new SolidBrush(Color.Black), new RectangleF(b.X, b.Y, en.X - b.X, en.Y - b.Y));
        }
        override public void Mouse_click(object sender, MouseEventArgs e)
        {

        }
    }
}
