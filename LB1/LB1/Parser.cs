using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LB1
{
    public class Parser
    {
        string[] lines;
        string s = "";

        System.Drawing.Color IntToColor(int argb)
        {
            var r = ((argb >> 16) & 0xff);
            var g = ((argb >> 8) & 0xff);
            var b = (argb & 0xff);
            return System.Drawing.Color.FromArgb(r, g, b);
        }
        private void UpdateBorder(ref Layer l, Point p)
        {
            l.xmin = Math.Min(l.xmin, p.point.x);
            l.xmax = Math.Max(l.xmax, p.point.x);
            l.ymin = Math.Min(l.ymin, p.point.y);
            l.ymax = Math.Max(l.ymax, p.point.y);
        }
        private void ParsePens(StreamReader reader)
        {
            s = reader.ReadLine();
            s = s.Replace('(', ' ');
            s = s.Replace(')', ' ');
            s = s.Replace(',', ' ');
            s = s.Trim();
            while (s.Contains("  ")) { s = s.Replace("  ", " "); }
            lines = s.Split(' ');
        }
        public Layer read(Layer layer, Stream path)
        {
            StreamReader reader = new StreamReader(path);
            while((s = reader.ReadLine()) != null)
            {
                while (s.Contains("  ")) { s = s.Replace("  ", " "); }

                lines = s.Split(' ');
                if(lines[0] == "Point")
                {
                    double x = Convert.ToDouble(lines[1].Replace('.', ','));
                    double y = Convert.ToDouble(lines[2].Replace('.', ','));
                    ParsePens(reader);
                    Point p = new Point(layer, 0);
                    p.br.Color = IntToColor(Convert.ToInt32(lines[2]));
                    p.point = new GeoPoint(x, y);
                    p.symbol = Convert.ToInt32(lines[1]);
                    p.size = Convert.ToInt32(lines[3]);
                    UpdateBorder(ref layer, p);
                    layer.Add(p);
                }
                if (lines[0] == "Text")
                {
                    Text t = new Text(new GeoPoint(0, 0), new GeoPoint(1, 1), lines[1], layer, 1);
                    lines = reader.ReadLine().Trim().Split(' ');
                    GeoPoint b = new GeoPoint(Convert.ToDouble(lines[0]), Convert.ToDouble(lines[1]));
                    GeoPoint e = new GeoPoint(Convert.ToDouble(lines[2]), Convert.ToDouble(lines[3]));
                    t.beginn = b;
                    t.endd = e;
                    UpdateBorder(ref layer, new Point(e));
                    layer.Add(t);
                }
                if (lines[0] == "Line")
                {
                    lines = reader.ReadLine().Trim().Split(' ');
                    GeoPoint b = new GeoPoint(Convert.ToDouble(lines[1]), Convert.ToDouble(lines[2]));
                    GeoPoint e = new GeoPoint(Convert.ToDouble(lines[3]), Convert.ToDouble(lines[4]));
                    UpdateBorder(ref layer, new Point(b));
                    UpdateBorder(ref layer, new Point(e));
                    Line p = new Line(b, e, layer, 2);
                    ParsePens(reader);
                    p.pen.Color = IntToColor(Convert.ToInt32(lines[3]));
                    p.pen.Width = Convert.ToInt32(lines[1]);
                    if (Convert.ToInt32(lines[2]) == 2)
                        p.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    else
                        p.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    layer.Add(p);
                }
                if(lines[0] == "Pline")
                {
                    Polyline p = new Polyline(layer, 3);
                    string l = reader.ReadLine().Trim();
                    int k = Convert.ToInt32(l);
                    for (int i = 0; i < k; ++i)
                    {
                        lines = reader.ReadLine().Trim().Split(' ');
                        GeoPoint gp = new GeoPoint(Convert.ToDouble(lines[0].Replace('.', ',')), Convert.ToDouble(lines[1].Replace('.', ',')));
                        p.AddNode(gp);
                        UpdateBorder(ref layer, new Point(gp));
                    }
                    //p.layer = layer;
                    ParsePens(reader);
                    p.pen.Color = IntToColor(Convert.ToInt32(lines[3]));
                    p.pen.Width = Convert.ToInt32(lines[1]);
                    if (Convert.ToInt32(lines[2]) == 2)
                        p.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    else
                        p.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    layer.Add(p);
                }
                if (lines[0] == "Region")
                {
                    int k = Convert.ToInt32(lines[1]);
                    for (int i = 0; i < k; ++i) 
                    {
                        Polygon p = new Polygon(layer, 4);
                        int countt = Convert.ToInt32(reader.ReadLine());
                        for (int j = 0; j < countt; ++j)
                        {
                            lines = reader.ReadLine().Trim().Split(' ');
                             GeoPoint gp = new GeoPoint(Convert.ToDouble(lines[0].Replace('.', ',')), Convert.ToDouble(lines[1].Replace('.', ',')));
                             UpdateBorder(ref layer, new Point(gp));
                             p.AddNode(Convert.ToDouble(lines[0].Replace('.', ',')), Convert.ToDouble(lines[1].Replace('.', ',')));
                        }
                        layer.Add(p);
                    }
                    
                    ParsePens(reader);
                    System.Drawing.Pen pen1 = new System.Drawing.Pen(IntToColor(Convert.ToInt32(lines[3])), Convert.ToInt32(lines[1]));
                    if (Convert.ToInt32(lines[2]) == 2)
                        pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    else
                        pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    ParsePens(reader);
                    System.Drawing.SolidBrush brush1 = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
                   // if (lines.Length == 4)
                        brush1.Color = (IntToColor(Convert.ToInt32(lines[2])));
                    for (int i = layer.ListOfMapObject.Count - 1; i >= layer.ListOfMapObject.Count - k; --i)
                    {
                        Polygon current = (Polygon)layer.ListOfMapObject[i];
                        current.pen = pen1;
                        current.br = brush1;
                    }
                }
            }
            reader.Close();
            return layer;
        }
    }
}
