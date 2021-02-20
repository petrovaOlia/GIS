using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace LB1
{
    public partial class Delete : Form
    {
        Stream path;
        Parser Parser1;
        int flag;
        
        public Delete()
        {
            InitializeComponent();
            Graphics g = this.CreateGraphics();
            Parser1 = new Parser();
            flag = 0;
            //this.Controls.Add(Karta);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void zoom_in_Click(object sender, EventArgs e)
        {
            Karta.scale *= 1.2;
            Karta.scale = Math.Min(1000, Karta.scale);
            //Karta.selMode = SelectionMode.None;
            //move.FlatAppearance.BorderColor = Color.White;
            //Karta.FindCenter();
            Karta.Refresh();
            //Refresh();
        }

        private void zoom_out_Click(object sender, EventArgs e)
        {
            Karta.scale /= 1.2;
            Karta.scale = Math.Max(0.001, Karta.scale);
            //Karta.selMode = SelectionMode.None;
            //move.FlatAppearance.BorderColor = Color.White;
            //Refresh();
            //Karta.FindCenter();
            Karta.Refresh();
        }

        private void PopUp(int ind)
        {
            if (ind != 0)
            {
                bool f = ListOfLayers.CheckedIndices.Contains(ind);
                bool s = ListOfLayers.CheckedIndices.Contains(ind - 1);
                Layer a = new Layer(Karta);
                a = Karta.ListOfLayer[ind - 1];
                Karta.ListOfLayer[ind - 1] = Karta.ListOfLayer[ind];
                Karta.ListOfLayer[ind] = a;
                object obj = ListOfLayers.Items[ind - 1];
                ListOfLayers.Items[ind - 1] = ListOfLayers.Items[ind];
                ListOfLayers.Items[ind] = obj;
                flag = 1;
                ListOfLayers.SetItemChecked(ind, s);
                ListOfLayers.SetItemChecked(ind - 1, f);
                flag = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog read = new OpenFileDialog();
            read.ShowDialog();
            try
            {
                if ((path = read.OpenFile()) != null)
                {
                    Layer layer = Parser1.read(new Layer(Karta), path);
                    //layer.visible = true;
                    Karta.AddLayer(layer);
                    ListOfLayers.Items.Add(read.SafeFileName.Remove(read.SafeFileName.Length - 4), true);
                    if (layer.IsTop())
                    {
                        int ind = ListOfLayers.Items.Count - 1;
                        while(ind > 0 && !Karta.ListOfLayer[ind-1].IsTop())
                        {
                            PopUp(ind);
                            --ind;
                        }
                    }
                }
            }
            catch
            {

            }
            Refresh();
        }

        private void SetSelectionMode(SelectionMode mode)
        {
            switch(mode)
            {
                case SelectionMode.None:
                    //move.BackColor = SystemColors.Control; //FlatAppearance.BorderColor = Color.White;
                    //btSelectCrossing.FlatAppearance.BorderColor = Color.White;
                    move.BackColor = SystemColors.Control;
                    btSelectCrossing.BackColor = SystemColors.Control;
                    break;
                case SelectionMode.Alone:
                    //move.FlatAppearance.BorderColor = Color.Aqua;
                    //btSelectCrossing.FlatAppearance.BorderColor = Color.White;
                    move.BackColor = SystemColors.ControlDark;
                    btSelectCrossing.BackColor = SystemColors.Control;
                    break;
                case SelectionMode.Group:
                    //move.FlatAppearance.BorderColor = Color.White;
                    //btSelectCrossing.FlatAppearance.BorderColor = Color.Aqua;
                    move.BackColor = SystemColors.Control;
                    btSelectCrossing.BackColor = SystemColors.ControlDark;
                    break;
            }
            Karta.selMode = mode;
            Karta.Refresh();
        }
        
        private void move_Click(object sender, EventArgs e)
        {
            Karta.ClearSelection();
            if (Karta.FindPoint)
            {
                //find.FlatAppearance.BorderColor = Color.White;
                Karta.UndoFind();
            }

            if (Karta.selMode == SelectionMode.Alone)
                SetSelectionMode(SelectionMode.None);
            else
                SetSelectionMode(SelectionMode.Alone);
        }

        private void ListOfLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(flag == 0)
                Karta.ListOfLayer[e.Index].visible = !Karta.ListOfLayer[e.Index].visible;
            //Karta.FindCenter();
            Refresh();
        }

        private void del_Click(object sender, EventArgs e)
        {
            int ind = ListOfLayers.SelectedIndex;
            if (ind == -1)
            {
                MessageBox.Show("Выберете слой для удаления!", "Ошибка", MessageBoxButtons.OK); 
                return;
            }
            Karta.ListOfLayer.RemoveAt(ind);
            ListOfLayers.Items.RemoveAt(ind);
            Karta.FindCenter();
            Karta.FindScale();
            Refresh();
        }
        private void up_Click(object sender, EventArgs e)
        {
            PopUp(ListOfLayers.SelectedIndex);
            Karta.Refresh();
        }

        private void down_Click(object sender, EventArgs e)
        {
            int ind = ListOfLayers.SelectedIndex;
            if (ind != Karta.ListOfLayer.Count - 1)
            {
                bool f = ListOfLayers.CheckedIndices.Contains(ind);
                bool s = ListOfLayers.CheckedIndices.Contains(ind + 1);
                Layer a = new Layer(Karta);
                a = Karta.ListOfLayer[ind + 1];
                Karta.ListOfLayer[ind + 1] = Karta.ListOfLayer[ind];
                Karta.ListOfLayer[ind] = a;
                object obj = ListOfLayers.Items[ind + 1];
                ListOfLayers.Items[ind + 1] = ListOfLayers.Items[ind];
                ListOfLayers.Items[ind] = obj;
                flag = 1;
                ListOfLayers.SetItemChecked(ind, s);
                ListOfLayers.SetItemChecked(ind + 1, f);
                flag = 0;
            }
            Karta.Refresh();
        }

        /*private void button1_Click_1(object sender, EventArgs e)
        {
            Karta.selMode = SelectionMode.None;
            //if (Karta._Click)
            if (Karta.FindPoint)
            {
                //find.FlatAppearance.BorderColor = Color.White;
                Karta.UndoFind();
                //Karta._Click = false;
            }
            else
            {
                //find.FlatAppearance.BorderColor = Color.Aqua;
                move.FlatAppearance.BorderColor = Color.White;
                Karta.FindPoint = true;
                //Karta._Click = true;
            }
            Refresh();
        }*/

        private void btSelectCrossing_Click(object sender, EventArgs e)
        {
            Karta.ClearSelection();
            if (Karta.selMode == SelectionMode.Group)
                SetSelectionMode(SelectionMode.None);
            else
                SetSelectionMode(SelectionMode.Group);
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            Karta.FindCenter();
            //Karta.FindScale();
            Karta.Refresh();
        }

        private void Delete_SizeChanged(object sender, EventArgs e)
        {
            Karta.FindScale();
            Karta.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Karta.FindScale();
            Karta.Refresh();
        }
    }
}
