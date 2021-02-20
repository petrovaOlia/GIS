using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    public enum SelectionMode
    {
        None,
        Alone,
        Group
    };

    public partial class Map : UserControl
    {
        int coord_x, coord_y;
        public double scale;
        public bool IsMove;//, _Click;
        public SelectionMode selMode; 
        GeoPoint Center;
        List<MapObject> acts = new List<MapObject>();
        public bool FindPoint;
        public List<Layer> ListOfLayer;
        public System.Drawing.Point MapToScreen(GeoPoint P)
        {
            double x;
            double y;
            x = (P.x - Center.x) * scale + Width / 2;
            y = Height / 2 - (P.y - Center.y) * scale;
            System.Drawing.Point p = new System.Drawing.Point((int)x, (int)y);
            return p; 
        }
        public GeoPoint ScreenToMap(System.Drawing.PointF A)
        {
            double Nx = (A.X - this.Width / 2.0) / scale + Center.x;
            double Ny = -((A.Y - this.Height / 2.0) / scale - Center.y);

            return new GeoPoint(Nx, Ny);
        }
        public Map()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ListOfLayer = new List<Layer>();
            scale = 1;
            ClearSelection();
            Center = new GeoPoint(0, 0);
            IsMove = false;
            selMode = SelectionMode.None;
            coord_x = 200;
            coord_y = 200;
            FindPoint = false;
        }

        public void ClearSelection()
        {
            foreach (MapObject act in acts)
            {
                act.ChangeColor();
            }
            acts.Clear();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (IsMove && selMode == SelectionMode.None)
            {
                Center.x = Center.x - (e.Location.X - coord_x) / scale;
                Center.y = Center.y + (e.Location.Y - coord_y) / scale;
                Refresh();
            }
            coord_x = e.X;
            coord_y = e.Y;
        }
        public void UndoFind()
        {
            FindPoint = false;
            for (int i = 0; i < ListOfLayer.Count; ++i)
                ListOfLayer[i].Undo();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            /*if (FindPoint)
            {
                for (int i = 0; i < ListOfLayer.Count; ++i)
                    ListOfLayer[i].SelectPoints(e);
                ClearSelection();
                Invalidate();
                return;
            }
            foreach (MapObject act in acts)
            {
                Pen a = new Pen(act.pen.Color, act.pen.Width);
                act.pen.Color = act.OldPen.Color;
                act.OldPen.Color = a.Color;
                SolidBrush b = new SolidBrush(act.br.Color);
                act.br.Color = act.oldbr.Color;
                act.oldbr.Color = b.Color;
            }*/
            ClearSelection();

            if (selMode != SelectionMode.None)
            {
                double d = 0;
                MapObject act = null;
                for (int i = 0; i < ListOfLayer.Count; ++i)
                //for (int i = ListOfLayer.Count - 1; i >= 0; --i)
                {
                    double d1= 0;
                    Layer l = ListOfLayer[i];
                    MapObject act1 = l.Selected(e, ref d1);
                    if (act1 != null)
                    {
                        if (l.IsTop())
                        {
                            if ((act == null) || (d1 < d))
                            {
                                act = act1;
                                d = d1;
                            }
                        }
                        else if ((selMode == SelectionMode.Alone) && (act == null))
                        {
                            act = act1;
                            break;
                        }
                    }
                }
                if (act != null)
                {
                    act.ChangeColor();
                    acts.Add(act);
                    if (selMode == SelectionMode.Group)
                    {
                        foreach (Layer l in ListOfLayer)
                        {
                            l.SelectIntersection(acts);
                        }
                        //act.ChangeColor();
                        //acts.Remove(act);
                    }
                }
            }
            else
                ClearSelection();
            Refresh();
        }
       
        public void AddLayer(Layer l)
        {
            l.ListOfMapObject.Sort();
            ListOfLayer.Add(l);
            double k = 10000000;
            double xmax = 0, ymax = 0, xmaxPR = 0, ymaxPR = 0, 
                xmin = 0, ymin = 0, xminPR = 1000000, yminPR = 1000000;
            for (int i = 0; i < ListOfLayer.Count; ++i)
            {
                   // k = Math.Min(k, Math.Min(this.Width / (ListOfLayer[i].xmax - ListOfLayer[i].xmin),
                     //   this.Height / (ListOfLayer[i].ymax - ListOfLayer[i].ymin)));

                    xmax = ListOfLayer[i].xmax;// + ListOfLayer[i].xmin;
                    ymax = ListOfLayer[i].ymax;// + ListOfLayer[i].ymin;
                    xmin = ListOfLayer[i].xmin;
                    ymin = ListOfLayer[i].ymin;
                    if (xmax > xmaxPR)
                    {
                        xmaxPR = xmax;
                    }
                    if (ymax > ymaxPR)
                    {
                        ymaxPR = ymax;
                    }
                    if (xmin < xminPR)
                    {
                        xminPR = xmin;
                    }
                    if (ymin < yminPR)
                    {
                        yminPR = ymin;
                    }
                Center = new GeoPoint((xmaxPR - xminPR) / 2.0 + xminPR, (ymaxPR - yminPR) / 2.0 + yminPR);
            }
            scale = Math.Min(this.Width / (xmaxPR - xminPR), this.Height / (ymaxPR - yminPR));
        }
        public void FindScale ()
        {
            double k = 10000000;
            double xmax = 0, ymax = 0, xmaxPR = 0, ymaxPR = 0,
                xmin = 0, ymin = 0, xminPR = 1000000, yminPR = 1000000;
            for (int i = 0; i < ListOfLayer.Count; ++i)
            {
                xmax = ListOfLayer[i].xmax;
                ymax = ListOfLayer[i].ymax;
                xmin = ListOfLayer[i].xmin;
                ymin = ListOfLayer[i].ymin;
                if (xmax > xmaxPR)
                {
                    xmaxPR = xmax;
                }
                if (ymax > ymaxPR)
                {
                    ymaxPR = ymax;
                }
                if (xmin < xminPR)
                {
                    xminPR = xmin;
                }
                if (ymin < yminPR)
                {
                    yminPR = ymin;
                }
            }
            scale = Math.Min(this.Width / (xmaxPR - xminPR), this.Height / (ymaxPR - yminPR));
        }
        public void FindCenter ()
        {
            double xmax = 0, ymax = 0, xmaxPR = 0, ymaxPR = 0,
                xmin = 0, ymin = 0, xminPR = 1000000, yminPR = 1000000;
            for (int i = 0; i < ListOfLayer.Count; ++i)
            {
                if (ListOfLayer[i].visible == true)
                {
                    xmax = ListOfLayer[i].xmax;// + ListOfLayer[i].xmin;
                    ymax = ListOfLayer[i].ymax;// + ListOfLayer[i].ymin;
                    xmin = ListOfLayer[i].xmin;
                    ymin = ListOfLayer[i].ymin;
                    if (xmax > xmaxPR)
                    {
                        xmaxPR = xmax;
                    }
                    if (ymax > ymaxPR)
                    {
                        ymaxPR = ymax;
                    }
                    if (xmin < xminPR)
                    {
                        xminPR = xmin;
                    }
                    if (ymin < yminPR)
                    {
                        yminPR = ymin;
                    }
                    Center = new GeoPoint((xmaxPR - xminPR) / 2.0 + xminPR, (ymaxPR - yminPR) / 2.0 + yminPR);
                    //Center = new GeoPoint((ListOfLayer[i].xmax + ListOfLayer[i].xmin) / 2.0, (ListOfLayer[i].ymax + ListOfLayer[i].ymin) / 2.0);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            IsMove = true;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            IsMove = false;
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
           /*
            for(int i = acts.Count - 1; i >= 0; i--)
            {
                MapObject act = acts[i];
                if (act.pen.Color != Color.Red)
                {
                    act.ChangeColor();
                }
                //if (act.pen.Color != Color.Red)
                   // acts.Remove(act);
            }*/
            if (FindPoint || selMode == SelectionMode.None)
                ClearSelection();

            for (int i = this.ListOfLayer.Count - 1; i >= 0; --i)
            {
                this.ListOfLayer[i].Paint(e);
            }
            
        }
    }
}
