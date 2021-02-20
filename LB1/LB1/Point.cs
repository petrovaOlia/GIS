using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace LB1
{
    class Point : MapObject
    {
        public GeoPoint point;
        public int symbol;
        public int size;
        override public MapObject Selected(MouseEventArgs e, ref double d)
        {
            //Graphics context = Graphics.FromHwnd(layer.map.Handle);
            //SizeF s = context.MeasureString("#", new Font("Map Symbols", size));
            PointF pp = new PointF(e.X, e.Y);
            d = Math.Sqrt((layer.map.ScreenToMap(pp).x - point.x) * (layer.map.ScreenToMap(pp).x - point.x)+
                (layer.map.ScreenToMap(pp).y - point.y) * (layer.map.ScreenToMap(pp).y - point.y));
            if (d < 20 / layer.map.scale)
                return this;
            return null;
        }
        public Point(Layer l, int pr): base(l, pr)
        {
            point = new GeoPoint(0, 0);
        }
        public Point(GeoPoint pointt, char symb = '*')
        {
            point = pointt;
            symbol = symb;
        }
       
        override public void Paint(PaintEventArgs e)
        {
            PointF t = this.layer.map.MapToScreen(this.point);
            e.Graphics.DrawString(((char)(this.symbol + 1)).ToString(), new Font("Map Symbols", this.size), br, t);
        }

        override public void Mouse_click(object sender, MouseEventArgs e)
        {

        }
    }
}
