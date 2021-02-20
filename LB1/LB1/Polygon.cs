using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    class Polygon : MapObject
    {
        public List<GeoPoint> Nodes;
        
        public Polygon(Layer l, int pr):base(l, pr)
        {
            Nodes = new List<GeoPoint>();
        }
        override public MapObject Selected(MouseEventArgs e, ref double d)
        {
            bool c = false;
            GeoPoint A = new GeoPoint();
            A = layer.map.ScreenToMap(new PointF(e.X, e.Y));
            for (int i = 0, j = Nodes.Count - 1; i < Nodes.Count; j = i++)
            {
                if ((((Nodes[i].y <= A.y) && (A.y < Nodes[j].y)) || ((Nodes[j].y <= A.y) && (A.y < Nodes[i].y))) &&
                  (A.x > (Nodes[j].x - Nodes[i].x) * (A.y - Nodes[i].y) / (Nodes[j].y - Nodes[i].y) + Nodes[i].x))
                    c = !c;
            }
            if (c)
                return this;
            return null;

        }

        public void AddNode(double x, double y)
        {
            Nodes.Add(new GeoPoint(x, y));
        }
        public void DeleteNode(int index)
        {
            Nodes.RemoveAt(index);
        }
        public void DeleteAllNodes()
        {
            Nodes.RemoveRange(0, Nodes.Count);
        }
        public int lenght()
        {
            return Nodes.Count;
        }
        public double SumOfSides()
        {
            double res = 0;
            int len = Nodes.Count;
            for (int i = 1; i <= len; ++i)
            {
                res += Math.Sqrt((Nodes[i % len].x - Nodes[i - 1].x) * (Nodes[i % len].x - Nodes[i - 1].x) + (Nodes[i % len].y - Nodes[i - 1].y) * (Nodes[i % len].y - Nodes[i - 1].y));
            }
            return res;
        }
        override public void Paint(PaintEventArgs e)
        {
            System.Drawing.Point[] list = new System.Drawing.Point[this.lenght()];
            for (int i = 0; i < this.lenght(); ++i)
                list[i] = this.layer.map.MapToScreen(Nodes[i]);
            e.Graphics.FillPolygon(this.br, list);
            PointF a = this.layer.map.MapToScreen(Nodes[0]);
            PointF b = new PointF(0, 0);
            for (int i = 1; i < this.lenght(); ++i)
            {
                b = this.layer.map.MapToScreen(Nodes[i]);
                e.Graphics.DrawLine(this.pen, a, b);
                a = b;
            }
            b = this.layer.map.MapToScreen(Nodes[0]);
            e.Graphics.DrawLine(this.pen, a, b);
           
            
        }
        override public void Mouse_click(object sender, MouseEventArgs e)
        {

        }
    }
}
