namespace CoffeeStore
{
    partial class fHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fLayoutTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numUD_FoodCount = new System.Windows.Forms.NumericUpDown();
            this.cbBoxFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCurrentTable = new System.Windows.Forms.Label();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.lViewBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPay = new System.Windows.Forms.Button();
            this.btnMoveTable = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_FoodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLayoutTable
            // 
            this.fLayoutTable.AutoScroll = true;
            this.fLayoutTable.Location = new System.Drawing.Point(12, 31);
            this.fLayoutTable.Name = "fLayoutTable";
            this.fLayoutTable.Padding = new System.Windows.Forms.Padding(5);
            this.fLayoutTable.Size = new System.Drawing.Size(560, 585);
            this.fLayoutTable.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numUD_FoodCount);
            this.panel1.Controls.Add(this.cbBoxFood);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.lblCurrentTable);
            this.panel1.Controls.Add(this.btnAddFood);
            this.panel1.Location = new System.Drawing.Point(578, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 69);
            this.panel1.TabIndex = 1;
            // 
            // numUD_FoodCount
            // 
            this.numUD_FoodCount.Location = new System.Drawing.Point(522, 24);
            this.numUD_FoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numUD_FoodCount.Name = "numUD_FoodCount";
            this.numUD_FoodCount.Size = new System.Drawing.Size(67, 22);
            this.numUD_FoodCount.TabIndex = 6;
            this.numUD_FoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbBoxFood
            // 
            this.cbBoxFood.FormattingEnabled = true;
            this.cbBoxFood.Location = new System.Drawing.Point(125, 37);
            this.cbBoxFood.Name = "cbBoxFood";
            this.cbBoxFood.Size = new System.Drawing.Size(264, 24);
            this.cbBoxFood.TabIndex = 5;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(125, 7);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(264, 24);
            this.cbCategory.TabIndex = 4;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lblCurrentTable
            // 
            this.lblCurrentTable.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCurrentTable.Location = new System.Drawing.Point(3, 3);
            this.lblCurrentTable.Name = "lblCurrentTable";
            this.lblCurrentTable.Size = new System.Drawing.Size(116, 60);
            this.lblCurrentTable.TabIndex = 3;
            this.lblCurrentTable.Text = "Bàn 2";
            this.lblCurrentTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(395, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(121, 60);
            this.btnAddFood.TabIndex = 0;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // lViewBill
            // 
            this.lViewBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lViewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lViewBill.GridLines = true;
            this.lViewBill.HideSelection = false;
            this.lViewBill.Location = new System.Drawing.Point(578, 102);
            this.lViewBill.Name = "lViewBill";
            this.lViewBill.Size = new System.Drawing.Size(592, 433);
            this.lViewBill.TabIndex = 2;
            this.lViewBill.UseCompatibleStateImageBehavior = false;
            this.lViewBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món";
            this.columnHeader1.Width = 288;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 100;
            // 
            // btnPay
            // 
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(472, 10);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(117, 60);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnMoveTable
            // 
            this.btnMoveTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveTable.Location = new System.Drawing.Point(3, 10);
            this.btnMoveTable.Name = "btnMoveTable";
            this.btnMoveTable.Size = new System.Drawing.Size(110, 30);
            this.btnMoveTable.TabIndex = 4;
            this.btnMoveTable.Text = "Chuyển bàn";
            this.btnMoveTable.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(3, 46);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(110, 22);
            this.numericUpDown1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tBoxTotalPrice);
            this.panel2.Controls.Add(this.numericUpDown3);
            this.panel2.Controls.Add(this.btnDiscount);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Controls.Add(this.btnMoveTable);
            this.panel2.Location = new System.Drawing.Point(578, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 75);
            this.panel2.TabIndex = 3;
            // 
            // tBoxTotalPrice
            // 
            this.tBoxTotalPrice.BackColor = System.Drawing.Color.White;
            this.tBoxTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxTotalPrice.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.tBoxTotalPrice.Location = new System.Drawing.Point(296, 27);
            this.tBoxTotalPrice.Name = "tBoxTotalPrice";
            this.tBoxTotalPrice.ReadOnly = true;
            this.tBoxTotalPrice.Size = new System.Drawing.Size(170, 26);
            this.tBoxTotalPrice.TabIndex = 8;
            this.tBoxTotalPrice.Text = "Tổng tiền";
            this.tBoxTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(137, 46);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(110, 22);
            this.numericUpDown3.TabIndex = 7;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Location = new System.Drawing.Point(137, 10);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(110, 30);
            this.btnDiscount.TabIndex = 6;
            this.btnDiscount.Text = "Giảm giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(63, 22);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(83, 22);
            this.thôngTinToolStripMenuItem.Text = "Thông tin";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lViewBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fLayoutTable);
            this.Controls.Add(this.menuStrip1);
            this.Name = "fHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUD_FoodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLayoutTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnMoveTable;
        private System.Windows.Forms.Label lblCurrentTable;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ListView lViewBill;
        private System.Windows.Forms.NumericUpDown numUD_FoodCount;
        private System.Windows.Forms.ComboBox cbBoxFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tBoxTotalPrice;
    }
}

