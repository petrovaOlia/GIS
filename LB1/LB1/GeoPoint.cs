using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    public class GeoPoint
    {
        public const double EPS = 1E-9;
        public double x, y;
        public GeoPoint ()
        {
            x = 0;
            y = 0;
        }
        public GeoPoint(double xx, double yy)
        {
            x = xx;
            y = yy;
        }
        public static bool operator <(GeoPoint p1, GeoPoint p2)
        {
            return p1.x < p2.x - EPS || Math.Abs(p1.x - p2.x) < EPS && p1.y < p2.y - EPS;
        }
        public static bool operator >(GeoPoint p1, GeoPoint p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
                return false;
            return !(p1.x < p2.x - EPS || Math.Abs(p1.x - p2.x) < EPS && p1.y < p2.y - EPS);
        }
    }
}
