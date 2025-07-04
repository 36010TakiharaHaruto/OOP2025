namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dtpDate = new DateTimePicker();
            cbAuthor = new ComboBox();
            groupBox1 = new GroupBox();
            rbImport = new RadioButton();
            rbOther = new RadioButton();
            rbHONDA = new RadioButton();
            rbSUBARU = new RadioButton();
            rbNISAN = new RadioButton();
            rbTOYOTA = new RadioButton();
            cbCarName = new ComboBox();
            tbReport = new TextBox();
            dgvRecord = new DataGridView();
            pbPicture = new PictureBox();
            btPicOpen = new Button();
            btPicDelete = new Button();
            btRecordAdd = new Button();
            btRecordModify = new Button();
            btRecordDelete = new Button();
            ofdPicFileOpen = new OpenFileDialog();
            btNewRecord = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(80, 26);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(80, 92);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 0;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(80, 159);
            label3.Name = "label3";
            label3.Size = new Size(79, 32);
            label3.TabIndex = 0;
            label3.Text = "メーカー";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(80, 224);
            label4.Name = "label4";
            label4.Size = new Size(62, 32);
            label4.TabIndex = 0;
            label4.Text = "車名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(80, 286);
            label5.Name = "label5";
            label5.Size = new Size(83, 32);
            label5.TabIndex = 0;
            label5.Text = "レポート";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(80, 387);
            label6.Name = "label6";
            label6.Size = new Size(62, 32);
            label6.TabIndex = 0;
            label6.Text = "一覧";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(532, 27);
            label7.Name = "label7";
            label7.Size = new Size(62, 32);
            label7.TabIndex = 0;
            label7.Text = "画像";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(173, 26);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 33);
            dtpDate.TabIndex = 1;
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(173, 95);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(200, 33);
            cbAuthor.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbImport);
            groupBox1.Controls.Add(rbOther);
            groupBox1.Controls.Add(rbHONDA);
            groupBox1.Controls.Add(rbSUBARU);
            groupBox1.Controls.Add(rbNISAN);
            groupBox1.Controls.Add(rbTOYOTA);
            groupBox1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox1.Location = new Point(164, 150);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(374, 50);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // rbImport
            // 
            rbImport.AutoSize = true;
            rbImport.Font = new Font("Yu Gothic UI", 9.75F);
            rbImport.Location = new Point(232, 12);
            rbImport.Name = "rbImport";
            rbImport.Size = new Size(65, 21);
            rbImport.TabIndex = 5;
            rbImport.TabStop = true;
            rbImport.Text = "輸入車";
            rbImport.UseVisualStyleBackColor = true;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Font = new Font("Yu Gothic UI", 9.75F);
            rbOther.Location = new Point(303, 12);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(60, 21);
            rbOther.TabIndex = 4;
            rbOther.TabStop = true;
            rbOther.Text = "その他";
            rbOther.UseVisualStyleBackColor = true;
            // 
            // rbHONDA
            // 
            rbHONDA.AutoSize = true;
            rbHONDA.Font = new Font("Yu Gothic UI", 9.75F);
            rbHONDA.Location = new Point(105, 12);
            rbHONDA.Name = "rbHONDA";
            rbHONDA.Size = new Size(57, 21);
            rbHONDA.TabIndex = 3;
            rbHONDA.TabStop = true;
            rbHONDA.Text = "ホンダ";
            rbHONDA.UseVisualStyleBackColor = true;
            // 
            // rbSUBARU
            // 
            rbSUBARU.AutoSize = true;
            rbSUBARU.Font = new Font("Yu Gothic UI", 9.75F);
            rbSUBARU.Location = new Point(168, 12);
            rbSUBARU.Name = "rbSUBARU";
            rbSUBARU.Size = new Size(58, 21);
            rbSUBARU.TabIndex = 2;
            rbSUBARU.TabStop = true;
            rbSUBARU.Text = "スバル";
            rbSUBARU.UseVisualStyleBackColor = true;
            // 
            // rbNISAN
            // 
            rbNISAN.AutoSize = true;
            rbNISAN.Font = new Font("Yu Gothic UI", 9.75F);
            rbNISAN.Location = new Point(47, 12);
            rbNISAN.Name = "rbNISAN";
            rbNISAN.Size = new Size(52, 21);
            rbNISAN.TabIndex = 1;
            rbNISAN.TabStop = true;
            rbNISAN.Text = "日産";
            rbNISAN.UseVisualStyleBackColor = true;
            // 
            // rbTOYOTA
            // 
            rbTOYOTA.AutoSize = true;
            rbTOYOTA.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            rbTOYOTA.Location = new Point(-1, 12);
            rbTOYOTA.Name = "rbTOYOTA";
            rbTOYOTA.Size = new Size(54, 21);
            rbTOYOTA.TabIndex = 0;
            rbTOYOTA.TabStop = true;
            rbTOYOTA.Text = "トヨタ";
            rbTOYOTA.UseVisualStyleBackColor = true;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(173, 223);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(200, 33);
            cbCarName.TabIndex = 2;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(173, 286);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(319, 77);
            tbReport.TabIndex = 4;
            // 
            // dgvRecord
            // 
            dgvRecord.AllowUserToAddRows = false;
            dgvRecord.AllowUserToDeleteRows = false;
            dgvRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecord.Location = new Point(184, 394);
            dgvRecord.Name = "dgvRecord";
            dgvRecord.ReadOnly = true;
            dgvRecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecord.Size = new Size(731, 192);
            dgvRecord.TabIndex = 5;
            dgvRecord.Click += dgvRecord_Click;
            // 
            // pbPicture
            // 
            pbPicture.BorderStyle = BorderStyle.FixedSingle;
            pbPicture.Location = new Point(621, 64);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(294, 247);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 6;
            pbPicture.TabStop = false;
            // 
            // btPicOpen
            // 
            btPicOpen.FlatStyle = FlatStyle.Flat;
            btPicOpen.Location = new Point(759, 37);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(75, 23);
            btPicOpen.TabIndex = 7;
            btPicOpen.Text = "開く...";
            btPicOpen.UseVisualStyleBackColor = true;
            btPicOpen.Click += btPicOpen_Click;
            // 
            // btPicDelete
            // 
            btPicDelete.FlatStyle = FlatStyle.Flat;
            btPicDelete.Location = new Point(840, 37);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(75, 23);
            btPicDelete.TabIndex = 8;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            btPicDelete.Click += btPicDelete_Click;
            // 
            // btRecordAdd
            // 
            btRecordAdd.FlatStyle = FlatStyle.Flat;
            btRecordAdd.Font = new Font("Yu Gothic UI", 15.75F);
            btRecordAdd.Location = new Point(621, 326);
            btRecordAdd.Name = "btRecordAdd";
            btRecordAdd.Size = new Size(88, 51);
            btRecordAdd.TabIndex = 7;
            btRecordAdd.Text = "追加";
            btRecordAdd.UseVisualStyleBackColor = true;
            btRecordAdd.Click += btRecordAdd_Click;
            // 
            // btRecordModify
            // 
            btRecordModify.FlatStyle = FlatStyle.Flat;
            btRecordModify.Font = new Font("Yu Gothic UI", 15.75F);
            btRecordModify.Location = new Point(724, 326);
            btRecordModify.Name = "btRecordModify";
            btRecordModify.Size = new Size(88, 51);
            btRecordModify.TabIndex = 7;
            btRecordModify.Text = "修正";
            btRecordModify.UseVisualStyleBackColor = true;
            btRecordModify.Click += btRecordModify_Click;
            // 
            // btRecordDelete
            // 
            btRecordDelete.FlatStyle = FlatStyle.Flat;
            btRecordDelete.Font = new Font("Yu Gothic UI", 15.75F);
            btRecordDelete.Location = new Point(827, 326);
            btRecordDelete.Name = "btRecordDelete";
            btRecordDelete.Size = new Size(88, 51);
            btRecordDelete.TabIndex = 7;
            btRecordDelete.Text = "削除";
            btRecordDelete.UseVisualStyleBackColor = true;
            btRecordDelete.Click += btRecordDelete_Click;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // btNewRecord
            // 
            btNewRecord.Location = new Point(396, 26);
            btNewRecord.Name = "btNewRecord";
            btNewRecord.Size = new Size(96, 34);
            btNewRecord.TabIndex = 9;
            btNewRecord.Text = "新規入力";
            btNewRecord.UseVisualStyleBackColor = true;
            btNewRecord.Click += btNewRecord_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 653);
            Controls.Add(btNewRecord);
            Controls.Add(btPicDelete);
            Controls.Add(btRecordDelete);
            Controls.Add(btRecordModify);
            Controls.Add(btRecordAdd);
            Controls.Add(btPicOpen);
            Controls.Add(pbPicture);
            Controls.Add(dgvRecord);
            Controls.Add(tbReport);
            Controls.Add(groupBox1);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(dtpDate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label1);
            Name = "Form1";
            Text = "cvnfhmfc";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpDate;
        private ComboBox cbAuthor;
        private GroupBox groupBox1;
        private RadioButton rbOther;
        private RadioButton rbHONDA;
        private RadioButton rbSUBARU;
        private RadioButton rbNISAN;
        private RadioButton rbTOYOTA;
        private RadioButton rbImport;
        private ComboBox cbCarName;
        private TextBox tbReport;
        private DataGridView dgvRecord;
        private PictureBox pbPicture;
        private Button btPicOpen;
        private Button btPicDelete;
        private Button btRecordAdd;
        private Button btRecordModify;
        private Button btRecordDelete;
        private OpenFileDialog ofdPicFileOpen;
        private Button btNewRecord;
    }
}
