using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    class Polyline : MapObject
    {
        List<GeoPoint> Nodes;
        public Polyline(Layer l, int pr):base(l, pr)
        {
            Nodes = new List<GeoPoint>();
        }
        override public MapObject Selected(MouseEventArgs e, ref double d)
        {
            PointF pp = new PointF(e.X, e.Y);
            double eps = 3; // / layer.map.scale
            double xx = layer.map.ScreenToMap(pp).x;
            double yy = layer.map.ScreenToMap(pp).y;
            for (int i = 0; i < Nodes.Count - 1; ++i)
            {
                double x1 = Nodes[i].x;
                double y1 = Nodes[i].y;
                double x2 = Nodes[i + 1].x;
                double y2 = Nodes[i + 1].y;
                GeoPoint v1 = new GeoPoint(x2 - x1, y2 - y1);
                GeoPoint v2 = new GeoPoint(xx - x1, yy - y1);
                d = Math.Abs(v1.x * v2.y - v2.x * v1.y) / (Math.Sqrt(v1.x * v1.x + v1.y * v1.y));
                if (d < eps && 
                    ( (xx >= x1 - eps) && (xx <= x2 + eps) || 
                      (xx >= x2 - eps) && (xx <= x1 + eps)
                    ) &&
                    ( (yy >= y1 - eps) && (yy <= y2 + eps) ||
                      (yy >= y2 - eps) && (yy <= y1 + eps)
                    )
                   )
                    return this;
            }
            return null;
        }
        public void AddNode(GeoPoint pointt)
        {
            Nodes.Add(pointt);
        }
        public void DeleteNode(int index)
        {
            Nodes.RemoveAt(index - 1);
        }
        public void DeleteAllNodes()
        {
            Nodes.RemoveRange(0, Nodes.Count);
        }
        public double lenght()
        {
            double res = 0;
            for (int i = 1; i < Nodes.Count; ++i)
            {
                res += Math.Sqrt((Nodes[i].x - Nodes[i - 1].x) * (Nodes[i].x - Nodes[i - 1].x) + (Nodes[i].y - Nodes[i - 1].y) * (Nodes[i].y - Nodes[i - 1].y));
            }
            return res;
        }
        override public void Paint(PaintEventArgs e)
        {
            PointF a = this.layer.map.MapToScreen(Nodes[0]);
            for (int i = 1; i < Nodes.Count; ++i)
            {
                PointF b = this.layer.map.MapToScreen(Nodes[i]);
                e.Graphics.DrawLine(this.pen, a, b);
                a = b;
            }
        }
        override public void Mouse_click(object sender, MouseEventArgs e)
        {

        }

        struct line
        {
            public double a, b, c;

            public line(GeoPoint p, GeoPoint q)
            {
                a = p.y - q.y;
                b = q.x - p.x;
                c = -a * p.x - b * p.y;
                norm();
            }

            public void norm()
            {
                double z = Math.Sqrt(a * a + b * b);
                    if (Math.Abs(z) > GeoPoint.EPS) {
                        a /= z;  b /= z;  c /= z;
                    }
            }

            public double dist(GeoPoint p) {
		        return a* p.x + b* p.y + c;
            }
        };

        bool betw(double l, double r, double x)
        {
            return Math.Min(l, r) <= x + GeoPoint.EPS && x <= Math.Max(l, r) + GeoPoint.EPS;
        }

        static void swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static double det(double a, double b, double c, double d)
        {
            return (a * d - b * c);
        }

        bool intersect_1d(double a, double b, double c, double d)
        {
            if (a > b) swap(ref a, ref b);
            if (c > d) swap(ref c, ref d);
            return Math.Max(a, c) <= Math.Min(b, d) + GeoPoint.EPS;
        }
        bool intersect(GeoPoint a, GeoPoint b, GeoPoint c, GeoPoint d)
        {
            if (!intersect_1d(a.x, b.x, c.x, d.x) || !intersect_1d(a.y, b.y, c.y, d.y))
                return false;
            line m = new line(a, b);
            line n = new line(c, d);
            double zn = det(m.a, m.b, n.a, n.b);
            if (Math.Abs(zn) < GeoPoint.EPS)
            {
                return !(Math.Abs(m.dist(c)) > GeoPoint.EPS || Math.Abs(n.dist(a)) > GeoPoint.EPS);
            }
            else
            {
                double xx = -det(m.c, m.b, n.c, n.b) / zn;
                double yy = -det(m.a, m.c, n.a, n.c) / zn;
                return betw(a.x, b.x, xx)
                    && betw(a.y, b.y, yy)
                    && betw(c.x, d.x, xx)
                    && betw(c.y, d.y, yy);
            }
        }
        public override bool IsCrossing(MapObject act)
        {
            Polyline sel_pline = (Polyline) act;
            for (int i = 0; i < sel_pline.Nodes.Count - 1; i++) {
                GeoPoint s1 = sel_pline.Nodes[i];
                GeoPoint s2 = sel_pline.Nodes[i + 1];
                for (int j = 0; j < Nodes.Count - 1; j++)
                {
                    GeoPoint p1 = Nodes[j];
                    GeoPoint p2 = Nodes[j + 1];
                    if (intersect(s1, s2, p1, p2))
                        return true;
                }
            }
            return false;
        }
    }
}
