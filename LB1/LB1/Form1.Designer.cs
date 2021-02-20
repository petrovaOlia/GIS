namespace LB1
{
    partial class Delete
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Add = new System.Windows.Forms.Button();
            this.ListOfLayers = new System.Windows.Forms.CheckedListBox();
            this.del = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.move = new System.Windows.Forms.ToolStripButton();
            this.btSelectCrossing = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.down = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Button();
            this.Karta = new LB1.Map();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add.Location = new System.Drawing.Point(6, 560);
            this.Add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(122, 72);
            this.Add.TabIndex = 3;
            this.Add.Text = "Добавить\r\nслой";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListOfLayers
            // 
            this.ListOfLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfLayers.FormattingEnabled = true;
            this.ListOfLayers.HorizontalScrollbar = true;
            this.ListOfLayers.Location = new System.Drawing.Point(6, 63);
            this.ListOfLayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListOfLayers.Name = "ListOfLayers";
            this.ListOfLayers.Size = new System.Drawing.Size(283, 487);
            this.ListOfLayers.TabIndex = 5;
            this.ListOfLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListOfLayers_ItemCheck);
            // 
            // del
            // 
            this.del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.del.Location = new System.Drawing.Point(125, 560);
            this.del.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(118, 72);
            this.del.TabIndex = 6;
            this.del.Text = "Удалить\r\nслой";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.del);
            this.panel1.Controls.Add(this.down);
            this.panel1.Controls.Add(this.up);
            this.panel1.Controls.Add(this.ListOfLayers);
            this.panel1.Location = new System.Drawing.Point(7, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 632);
            this.panel1.TabIndex = 13;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.move,
            this.btSelectCrossing});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(296, 32);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LB1.Properties.Resources.P;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Увеличить масштаб";
            this.toolStripButton1.Click += new System.EventHandler(this.zoom_in_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::LB1.Properties.Resources.m;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Уменьшить масштаб";
            this.toolStripButton2.Click += new System.EventHandler(this.zoom_out_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::LB1.Properties.Resources.Center;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Центрирование";
            this.toolStripButton3.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // move
            // 
            this.move.BackColor = System.Drawing.SystemColors.Control;
            this.move.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.move.Image = global::LB1.Properties.Resources.select_hand;
            this.move.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(29, 29);
            this.move.Text = "Выделение объекта";
            this.move.Click += new System.EventHandler(this.move_Click);
            // 
            // btSelectCrossing
            // 
            this.btSelectCrossing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSelectCrossing.Image = global::LB1.Properties.Resources.intersection;
            this.btSelectCrossing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSelectCrossing.Name = "btSelectCrossing";
            this.btSelectCrossing.Size = new System.Drawing.Size(29, 29);
            this.btSelectCrossing.Text = "Выделение полилиний, пересекающих выбранную полилинию";
            this.btSelectCrossing.Click += new System.EventHandler(this.btSelectCrossing_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::LB1.Properties.Resources._111;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Начальный масштаб";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // down
            // 
            this.down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.down.BackgroundImage = global::LB1.Properties.Resources.downn;
            this.down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.down.Location = new System.Drawing.Point(243, 596);
            this.down.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(46, 36);
            this.down.TabIndex = 8;
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // up
            // 
            this.up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.up.BackgroundImage = global::LB1.Properties.Resources.Upp;
            this.up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.up.Location = new System.Drawing.Point(243, 560);
            this.up.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(46, 38);
            this.up.TabIndex = 7;
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // Karta
            // 
            this.Karta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Karta.BackColor = System.Drawing.Color.White;
            this.Karta.Location = new System.Drawing.Point(310, 14);
            this.Karta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Karta.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Karta.MinimumSize = new System.Drawing.Size(450, 380);
            this.Karta.Name = "Karta";
            this.Karta.Size = new System.Drawing.Size(903, 620);
            this.Karta.TabIndex = 0;
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 648);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Karta);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Delete";
            this.Text = "GIS";
            this.SizeChanged += new System.EventHandler(this.Delete_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Map Karta;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.CheckedListBox ListOfLayers;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton move;
        private System.Windows.Forms.ToolStripButton btSelectCrossing;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}

