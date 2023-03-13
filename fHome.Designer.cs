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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHome));
            this.fLayoutTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddFood = new CoffeeStore.csControls.csButton();
            this.numUD_FoodCount = new System.Windows.Forms.NumericUpDown();
            this.cbBoxFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCurrentTable = new System.Windows.Forms.Label();
            this.lViewBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPay = new CoffeeStore.csControls.csButton();
            this.tBoxTotalPrice = new CoffeeStore.csControls.csTextBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmItemAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_FoodCount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLayoutTable
            // 
            this.fLayoutTable.AutoScroll = true;
            this.fLayoutTable.BackColor = System.Drawing.SystemColors.Control;
            this.fLayoutTable.Location = new System.Drawing.Point(12, 29);
            this.fLayoutTable.Name = "fLayoutTable";
            this.fLayoutTable.Padding = new System.Windows.Forms.Padding(5);
            this.fLayoutTable.Size = new System.Drawing.Size(560, 587);
            this.fLayoutTable.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddFood);
            this.panel1.Controls.Add(this.numUD_FoodCount);
            this.panel1.Controls.Add(this.cbBoxFood);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.lblCurrentTable);
            this.panel1.Location = new System.Drawing.Point(578, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 67);
            this.panel1.TabIndex = 1;
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAddFood.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAddFood.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddFood.BorderRadius = 0;
            this.btnAddFood.BorderSize = 0;
            this.btnAddFood.FlatAppearance.BorderSize = 0;
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.Color.Ivory;
            this.btnAddFood.Location = new System.Drawing.Point(395, 6);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(120, 60);
            this.btnAddFood.TabIndex = 4;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.TextColor = System.Drawing.Color.Ivory;
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // numUD_FoodCount
            // 
            this.numUD_FoodCount.Location = new System.Drawing.Point(522, 25);
            this.numUD_FoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numUD_FoodCount.Name = "numUD_FoodCount";
            this.numUD_FoodCount.Size = new System.Drawing.Size(67, 22);
            this.numUD_FoodCount.TabIndex = 3;
            this.numUD_FoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbBoxFood
            // 
            this.cbBoxFood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbBoxFood.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBoxFood.FormattingEnabled = true;
            this.cbBoxFood.Location = new System.Drawing.Point(125, 38);
            this.cbBoxFood.Name = "cbBoxFood";
            this.cbBoxFood.Size = new System.Drawing.Size(264, 24);
            this.cbBoxFood.TabIndex = 2;
            // 
            // cbCategory
            // 
            this.cbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(125, 8);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(264, 24);
            this.cbCategory.TabIndex = 1;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lblCurrentTable
            // 
            this.lblCurrentTable.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTable.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCurrentTable.Location = new System.Drawing.Point(3, 4);
            this.lblCurrentTable.Name = "lblCurrentTable";
            this.lblCurrentTable.Size = new System.Drawing.Size(116, 60);
            this.lblCurrentTable.TabIndex = 3;
            this.lblCurrentTable.Text = "Tên bàn";
            this.lblCurrentTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lViewBill.TabStop = false;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Controls.Add(this.tBoxTotalPrice);
            this.panel2.Controls.Add(this.numericUpDown3);
            this.panel2.Controls.Add(this.btnDiscount);
            this.panel2.Location = new System.Drawing.Point(578, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 75);
            this.panel2.TabIndex = 3;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPay.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPay.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPay.BorderRadius = 0;
            this.btnPay.BorderSize = 0;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.Ivory;
            this.btnPay.Location = new System.Drawing.Point(454, 5);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(125, 60);
            this.btnPay.TabIndex = 11;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.TextColor = System.Drawing.Color.Ivory;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click_1);
            // 
            // tBoxTotalPrice
            // 
            this.tBoxTotalPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tBoxTotalPrice.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tBoxTotalPrice.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tBoxTotalPrice.BorderRadius = 0;
            this.tBoxTotalPrice.BorderSize = 2;
            this.tBoxTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxTotalPrice.ForeColor = System.Drawing.Color.Black;
            this.tBoxTotalPrice.Location = new System.Drawing.Point(288, 18);
            this.tBoxTotalPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxTotalPrice.Multiline = false;
            this.tBoxTotalPrice.Name = "tBoxTotalPrice";
            this.tBoxTotalPrice.Padding = new System.Windows.Forms.Padding(7);
            this.tBoxTotalPrice.PasswordChar = false;
            this.tBoxTotalPrice.PlaceHolderColor = System.Drawing.Color.DimGray;
            this.tBoxTotalPrice.PlaceHolderText = "";
            this.tBoxTotalPrice.ReadOnly = true;
            this.tBoxTotalPrice.Size = new System.Drawing.Size(160, 35);
            this.tBoxTotalPrice.TabIndex = 10;
            this.tBoxTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBoxTotalPrice.Texts = "";
            this.tBoxTotalPrice.UnderlineStyle = false;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(125, 29);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(110, 22);
            this.numericUpDown3.TabIndex = 7;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Location = new System.Drawing.Point(9, 23);
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
            this.tsmItemAdmin,
            this.tsmItemInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmItemAdmin
            // 
            this.tsmItemAdmin.Enabled = false;
            this.tsmItemAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmItemAdmin.Name = "tsmItemAdmin";
            this.tsmItemAdmin.Size = new System.Drawing.Size(63, 22);
            this.tsmItemAdmin.Text = "Admin";
            this.tsmItemAdmin.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // tsmItemInfo
            // 
            this.tsmItemInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tsmItemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmItemInfo.Name = "tsmItemInfo";
            this.tsmItemInfo.Size = new System.Drawing.Size(83, 22);
            this.tsmItemInfo.Text = "Thông tin";
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
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1182, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lViewBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fLayoutTable);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUD_FoodCount)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLayoutTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentTable;
        private System.Windows.Forms.ListView lViewBill;
        private System.Windows.Forms.NumericUpDown numUD_FoodCount;
        private System.Windows.Forms.ComboBox cbBoxFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmItemAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmItemInfo;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private csControls.csTextBox tBoxTotalPrice;
        private csControls.csButton btnPay;
        private csControls.csButton btnAddFood;
    }
}

