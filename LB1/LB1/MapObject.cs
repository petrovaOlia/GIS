using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    public abstract class MapObject: IComparable<MapObject>
    {
        public bool active;
        
        public Layer layer;
        public Pen OldPen;
        public Pen pen;
        public int priority;
        public SolidBrush oldbr, br;
        public abstract MapObject Selected(MouseEventArgs e, ref double d);
        public virtual bool IsCrossing(MapObject act) { return false; }
        public abstract void Paint(PaintEventArgs e);
        public bool OK()
        {
            if (layer == null)
                return false;
            if (layer.map == null)
                return false;
            return true;
        }
        public int CompareTo(MapObject b)
        {
            return this.priority.CompareTo(b.priority);
        }
        public abstract void Mouse_click(object sender, MouseEventArgs e);
        public MapObject()
        {
        }
        public MapObject(Layer obj, int pr)
        {
            layer = obj;
            OldPen = new Pen(Color.Red, 3);
            pen = new Pen(Color.Black);
            br = new SolidBrush(Color.Black);
            oldbr = new SolidBrush(Color.Red);
            priority = pr;
        }

        public void ChangeColor()
        {
            Pen a = new Pen(pen.Color, pen.Width);
            pen.Color = OldPen.Color;
            OldPen.Color = a.Color;
            SolidBrush b = new SolidBrush(br.Color);
            br.Color = oldbr.Color;
            oldbr.Color = b.Color;
        }

    }
}
