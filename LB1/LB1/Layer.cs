using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    public class Layer
    {
        public List<MapObject> ListOfMapObject;
        public Map map { get; set; }
        public double xmin, xmax, ymin, ymax;
        public bool visible;
       
        public Layer(Map m)
        {
            ListOfMapObject = new List<MapObject>();
            map = m;
            visible = false;
            xmin = 100000;
            xmax = 0;
            ymin = 100000;
            ymax = 0;
        }
        public void Undo()
        {
            int k = 0;
            while (ListOfMapObject[k].priority == 0)
            {
                if(!ListOfMapObject[k].active)
                {
                    k++;
                    continue;
                }
                Pen a = new Pen(ListOfMapObject[k].pen.Color, ListOfMapObject[k].pen.Width);
                ListOfMapObject[k].pen = ListOfMapObject[k].OldPen;
                ListOfMapObject[k].OldPen = a;
                SolidBrush b = new SolidBrush(ListOfMapObject[k].br.Color);
                ListOfMapObject[k].br = ListOfMapObject[k].oldbr;
                ListOfMapObject[k].oldbr = b;
                k++;
            }
        }
        private bool Isfind(Point obj, Polygon p)
        {
            bool c = false;
            for (int i = 0, j = p.Nodes.Count - 1; i < p.Nodes.Count; j = i++)
            {
                if ((((p.Nodes[i].y <= obj.point.y) && (obj.point.y < p.Nodes[j].y)) || ((p.Nodes[j].y <= obj.point.y) && (obj.point.y < p.Nodes[i].y))) &&
                  (obj.point.x > (p.Nodes[j].x - p.Nodes[i].x) * (obj.point.y - p.Nodes[i].y) / (p.Nodes[j].y - p.Nodes[i].y) + p.Nodes[i].x))
                    c = !c;
            }
            if (c)
                return true;
            return false;
        }
        /*
        public void SelectPoints(MouseEventArgs e)
        {
            if (!visible)
                return;
            MapObject act = null;
            for (int i = 0; i < ListOfMapObject.Count; ++i)
            {
                act = ListOfMapObject[i].Selected(e);
                if (act != null)
                {
                    if (act.priority == 4 && map.FindPoint)
                    {
                        int k = 0;
                        while (ListOfMapObject[k].priority == 0)
                        {
                            if (Isfind((Point)ListOfMapObject[k], (Polygon) act))
                            {
                                ListOfMapObject[k].active = true;
                                Pen a = new Pen(ListOfMapObject[k].pen.Color, ListOfMapObject[k].pen.Width);
                                ListOfMapObject[k].pen = ListOfMapObject[k].OldPen;
                                ListOfMapObject[k].OldPen = a;
                                SolidBrush b = new SolidBrush(ListOfMapObject[k].br.Color);
                                ListOfMapObject[k].br = ListOfMapObject[k].oldbr;
                                ListOfMapObject[k].oldbr = b;
                            }
                            k++;
                        }
                    }
                }
            }
        }*/

        public bool IsTop()
        {
            if (ListOfMapObject.Count() == 0)
                return false;
            return ListOfMapObject[0] is Polyline;
        }

        public MapObject Selected(MouseEventArgs e, ref double d)
        {
            if (!visible)
                return null;
            MapObject act = null;
            for (int i = 0; i < ListOfMapObject.Count; ++i)
            {
                act = ListOfMapObject[i].Selected(e, ref d);
                if (act != null)
                    return act;
            }
            return act;
        }
        public void SelectIntersection(List<MapObject> acts)
        {
            if (visible && acts.Count > 0)
            {
                MapObject act = acts[0];
                if (act is Polyline)
                {
                    foreach (MapObject mo in ListOfMapObject)
                    {
                        if (mo is Polyline && mo != act)
                            if (mo.IsCrossing(act))
                            {
                                mo.ChangeColor();
                                acts.Add(mo);
                            }
                    }
                }
            }
        }
        public void Add(MapObject obj)
        {
            ListOfMapObject.Add(obj);
        }
        public void DeleteObject(MapObject obj)
        {
            ListOfMapObject.Remove(obj);
        }
        public void Paint(PaintEventArgs e)
        {
            int len = this.ListOfMapObject.Count;
            for (int i = 0; i < this.ListOfMapObject.Count; ++i)
            {
                if (visible)
                    this.ListOfMapObject[len - i - 1].Paint(e);
            }
        }

        
    }
}
