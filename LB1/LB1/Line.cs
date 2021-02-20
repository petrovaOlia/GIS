using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    class Line : MapObject
    {
        GeoPoint begin { get; set; }
        GeoPoint end {get; set;}
        public Line(GeoPoint beginn, GeoPoint endd, Layer obj, int pr): base(obj, pr)
        {
            begin = beginn;
            end = endd;
            pen = new Pen(Color.Black);
        }
        public Line(double a, double b, double c, double d, Layer obj, int pr) : base(obj, pr)
        {
            begin.x = a;
            begin.y = b;
            end.x = c;
            end.y = d;
        }
        override public MapObject Selected(MouseEventArgs e, ref double d)
        {
            double xx = layer.map.ScreenToMap(new PointF(e.X, e.Y)).x;
            double yy = layer.map.ScreenToMap(new PointF(e.X, e.Y)).y;
             GeoPoint v1 = new GeoPoint(end.x - begin.x, end.y - begin.y);
             GeoPoint v2 = new GeoPoint(e.X - begin.x, e.Y - begin.y);
             double v1x = layer.map.MapToScreen(v1).X;
             double v1y = layer.map.MapToScreen(v1).Y;
             double v2x = layer.map.MapToScreen(v2).X;
             double v2y = layer.map.MapToScreen(v2).Y;
             d = Math.Abs(v1x * v2y - v2x * v1y) / (Math.Sqrt(v1x * v1x + v1y * v1y));
             if (d < 3 / layer.map.scale && ((xx >= begin.x - 3 / layer.map.scale) && (xx <= end.x + 3 / layer.map.scale) ||
                    (xx >= end.x - 3 / layer.map.scale) && (xx <= begin.x + 3 / layer.map.scale)))
                 return this;
             return null;

        }
        double lenght()
        {
            return (Math.Sqrt((begin.x - end.x) * (begin.x - end.x) + (begin.y - end.y) * (begin.y - end.y)));
        }
        override public void Paint(PaintEventArgs e)
        {
           PointF a = this.layer.map.MapToScreen(this.begin);
            PointF b = this.layer.map.MapToScreen(this.end);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 2), a, b);
        }
        override public void Mouse_click(object sender, MouseEventArgs e)
        {

        }
    }
}
