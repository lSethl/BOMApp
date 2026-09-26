namespace bomApp
{
    partial class BOMProject
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOMProject));
            cmbSearchField = new ComboBox();
            label1 = new Label();
            txtMaterial = new TextBox();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            btnList = new Button();
            btnExcelSelect = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnUpdate = new Button();
            txtLocation = new TextBox();
            pictureBox1 = new PictureBox();
            btnFilePicture = new Button();
            openFileDialog2 = new OpenFileDialog();
            panel2 = new Panel();
            btnLogHistory = new Button();
            label10 = new Label();
            btnDelete = new Button();
            button1 = new Button();
            txtDecreaseQuantity = new TextBox();
            btnClear = new Button();
            label9 = new Label();
            label5 = new Label();
            label8 = new Label();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            label2 = new Label();
            lblLocation = new Label();
            txtQuantity = new TextBox();
            txtValue = new TextBox();
            txtFootprint = new TextBox();
            txtComment = new TextBox();
            flowLog = new FlowLayoutPanel();
            linkLabel1 = new LinkLabel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(cmbSearchField);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtMaterial);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(12, 416);
            panel1.Name = "panel1";
            panel1.Size = new Size(694, 183);
            panel1.TabIndex = 31;
            // 
            // cmbSearchField
            // 
            cmbSearchField.BackColor = Color.LightSteelBlue;
            cmbSearchField.Cursor = Cursors.Hand;
            cmbSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchField.FlatStyle = FlatStyle.Flat;
            cmbSearchField.FormattingEnabled = true;
            cmbSearchField.Items.AddRange(new object[] { "All Fields", "Comment", "Footprint", "Value" });
            cmbSearchField.Location = new Point(386, 21);
            cmbSearchField.Name = "cmbSearchField";
            cmbSearchField.Size = new Size(179, 23);
            cmbSearchField.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(35, 47, 62);
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 12;
            label1.Text = "BOM Listesi";
            // 
            // txtMaterial
            // 
            txtMaterial.BackColor = Color.LightSteelBlue;
            txtMaterial.BorderStyle = BorderStyle.FixedSingle;
            txtMaterial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtMaterial.Location = new Point(182, 18);
            txtMaterial.Name = "txtMaterial";
            txtMaterial.Size = new Size(193, 25);
            txtMaterial.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightSteelBlue;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSearch.ForeColor = Color.FromArgb(35, 47, 62);
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(574, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(46, 25);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "ARA";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(59, 51);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(561, 125);
            dataGridView1.TabIndex = 98;
            dataGridView1.TabStop = false;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // btnList
            // 
            btnList.Cursor = Cursors.Hand;
            btnList.FlatStyle = FlatStyle.Flat;
            btnList.Location = new Point(394, 233);
            btnList.Name = "btnList";
            btnList.Size = new Size(82, 27);
            btnList.TabIndex = 21;
            btnList.Text = "Listele";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // btnExcelSelect
            // 
            btnExcelSelect.BackColor = Color.Transparent;
            btnExcelSelect.Cursor = Cursors.Hand;
            btnExcelSelect.FlatStyle = FlatStyle.Flat;
            btnExcelSelect.Location = new Point(597, 275);
            btnExcelSelect.Name = "btnExcelSelect";
            btnExcelSelect.Size = new Size(82, 27);
            btnExcelSelect.TabIndex = 23;
            btnExcelSelect.Text = "Excel Seç";
            btnExcelSelect.UseVisualStyleBackColor = false;
            btnExcelSelect.Click += btnExcelSelect_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnUpdate
            // 
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(509, 233);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 27);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(387, 155);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(293, 25);
            txtLocation.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(261, 196);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnFilePicture
            // 
            btnFilePicture.Cursor = Cursors.Hand;
            btnFilePicture.FlatStyle = FlatStyle.Flat;
            btnFilePicture.Location = new Point(597, 233);
            btnFilePicture.Name = "btnFilePicture";
            btnFilePicture.Size = new Size(82, 27);
            btnFilePicture.TabIndex = 22;
            btnFilePicture.Text = "Resim Seç";
            btnFilePicture.UseVisualStyleBackColor = true;
            btnFilePicture.Click += btnFilePicture_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnLogHistory);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(txtDecreaseQuantity);
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnList);
            panel2.Controls.Add(btnFilePicture);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnExcelSelect);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblLocation);
            panel2.Controls.Add(txtQuantity);
            panel2.Controls.Add(txtValue);
            panel2.Controls.Add(txtLocation);
            panel2.Controls.Add(txtFootprint);
            panel2.Controls.Add(txtComment);
            panel2.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            panel2.Location = new Point(12, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(694, 321);
            panel2.TabIndex = 30;
            // 
            // btnLogHistory
            // 
            btnLogHistory.Cursor = Cursors.Hand;
            btnLogHistory.FlatStyle = FlatStyle.Flat;
            btnLogHistory.Location = new Point(394, 275);
            btnLogHistory.Name = "btnLogHistory";
            btnLogHistory.Size = new Size(82, 27);
            btnLogHistory.TabIndex = 29;
            btnLogHistory.Text = "LOG";
            btnLogHistory.UseVisualStyleBackColor = true;
            btnLogHistory.Click += btnLogHistory_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.FromArgb(35, 47, 62);
            label10.Location = new Point(275, 187);
            label10.Name = "label10";
            label10.Size = new Size(107, 17);
            label10.TabIndex = 28;
            label10.Text = "Quentity Azalt :";
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(306, 275);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 27);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(509, 275);
            button1.Name = "button1";
            button1.Size = new Size(82, 27);
            button1.TabIndex = 8;
            button1.Text = "Azalt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtDecreaseQuantity
            // 
            txtDecreaseQuantity.Location = new Point(386, 184);
            txtDecreaseQuantity.Name = "txtDecreaseQuantity";
            txtDecreaseQuantity.Size = new Size(293, 25);
            txtDecreaseQuantity.TabIndex = 6;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(306, 233);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 27);
            btnClear.TabIndex = 20;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.FromArgb(35, 47, 62);
            label9.Location = new Point(311, 34);
            label9.Name = "label9";
            label9.Size = new Size(70, 17);
            label9.TabIndex = 23;
            label9.Text = "Quantity :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = Color.FromArgb(35, 47, 62);
            label5.Location = new Point(8, 3);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 15;
            label5.Text = "Ürün Bilgisi";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.FromArgb(35, 47, 62);
            label8.Location = new Point(305, 65);
            label8.Name = "label8";
            label8.Size = new Size(76, 17);
            label8.TabIndex = 22;
            label8.Text = "Comment :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(35, 47, 62);
            label3.Location = new Point(275, 158);
            label3.Name = "label3";
            label3.Size = new Size(106, 17);
            label3.TabIndex = 12;
            label3.Text = "Enter Location :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(35, 47, 62);
            label6.Location = new Point(330, 127);
            label6.Name = "label6";
            label6.Size = new Size(51, 17);
            label6.TabIndex = 20;
            label6.Text = "Value :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(35, 47, 62);
            label7.Location = new Point(306, 98);
            label7.Name = "label7";
            label7.Size = new Size(75, 17);
            label7.TabIndex = 21;
            label7.Text = "Footprint :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(35, 47, 62);
            label2.Location = new Point(32, 243);
            label2.Name = "label2";
            label2.Size = new Size(104, 17);
            label2.TabIndex = 11;
            label2.Text = "Konum Bilgisi :";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.ForeColor = Color.FromArgb(35, 47, 62);
            lblLocation.Location = new Point(132, 243);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(97, 17);
            lblLocation.TabIndex = 13;
            lblLocation.Text = "Ürün Konumu";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(387, 31);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(293, 25);
            txtQuantity.TabIndex = 1;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(387, 124);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(293, 25);
            txtValue.TabIndex = 4;
            // 
            // txtFootprint
            // 
            txtFootprint.Location = new Point(387, 93);
            txtFootprint.Name = "txtFootprint";
            txtFootprint.Size = new Size(293, 25);
            txtFootprint.TabIndex = 3;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(387, 62);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(293, 25);
            txtComment.TabIndex = 2;
            // 
            // flowLog
            // 
            flowLog.AutoScroll = true;
            flowLog.BackColor = Color.Transparent;
            flowLog.FlowDirection = FlowDirection.TopDown;
            flowLog.Location = new Point(712, 89);
            flowLog.Name = "flowLog";
            flowLog.Size = new Size(360, 262);
            flowLog.TabIndex = 13;
            flowLog.WrapContents = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = Color.White;
            linkLabel1.Location = new Point(830, 568);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(172, 17);
            linkLabel1.TabIndex = 99;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "• Developer By Efe AKBIYIK";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // BOMProject
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1089, 604);
            Controls.Add(linkLabel1);
            Controls.Add(flowLog);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BOMProject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BOM Tracking System v1.0.0";
            FormClosed += BOMProject_FormClosed;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnList;
        private Button btnExcelSelect;
        private Button btnSearch;
        private DataGridView dataGridView1;
        private TextBox txtMaterial;
        private OpenFileDialog openFileDialog1;
        private Button btnUpdate;
        private TextBox txtLocation;
        private PictureBox pictureBox1;
        private Button btnFilePicture;
        private OpenFileDialog openFileDialog2;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label lblLocation;
        private Label label5;
        private TextBox txtValue;
        private TextBox txtFootprint;
        private TextBox txtComment;
        private TextBox txtQuantity;
        private Label label6;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnClear;
        private ComboBox cmbSearchField;
        private TextBox txtDecreaseQuantity;
        private Button btnDelete;
        private Button button1;
        private Label label10;
        private Label label3;
        private FlowLayoutPanel flowLog;
        private Button btnLogHistory;
        private LinkLabel linkLabel1;
    }
}
